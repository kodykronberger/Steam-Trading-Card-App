using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using OrderEntrySystem.Utilities;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent the browse all cards view model.
    /// </summary>
    public class BrowseAllCardsViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The user-input card search string (entered in the text box).
        /// </summary>
        private string cardSearchTextBox;

        /// <summary>
        /// The view source collection.
        /// </summary>
        private CollectionViewSource makeViewSource;

        /// <summary>
        /// The database repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// The sorting column header name.
        /// </summary>
        private string sortColumnName;

        /// <summary>
        /// The sort direction of the list (ascending or descending).
        /// </summary>
        private ListSortDirection sortDirection;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="repository">The database repository.</param>
        public BrowseAllCardsViewModel(Repository repository)
            : base("Browse All Cards")
        {
            this.repository = repository;
            this.makeViewSource = new CollectionViewSource();
            this.makeViewSource.Source = this.Cards;
            this.SortCommand = new DelegateCommand(this.Sort);
        }

        /// <summary>
        /// Gets the view models for all cards in the repository.
        /// </summary>
        public ObservableCollection<CardViewModel> Cards
        {
            get
            {
                // Get a list of view models for each card in the repository.
                IEnumerable<CardViewModel> cards =
                    from card in this.repository.GetCards()
                    orderby card.Name ascending
                    select new CardViewModel(card, this.repository);

                // Create observable collection from the list.
                return new ObservableCollection<CardViewModel>(cards);
            }
        }

        /// <summary>
        /// Gets or sets the card search text.
        /// </summary>
        public string CardSearchTextBox
        {
            get
            {
                return this.cardSearchTextBox;
            }
            set
            {
                this.cardSearchTextBox = value;
                this.OnPropertyChanged("CardSearchTextBox");
            }
        }

        /// <summary>
        /// Gets the view models for all cards in the repository.
        /// </summary>
        public ObservableCollection<CardViewModel> GetCard
        {
            get
            {
                // Get a list of view models for each card in the repository.
                IEnumerable<CardViewModel> cards =
                    from card in this.repository.GetCards()
                    where card.Name == this.CardSearchTextBox
                    orderby card.Name ascending
                    select new CardViewModel(card, this.repository);

                // Create observable collection from the list.
                return new ObservableCollection<CardViewModel>(cards);
            }
        }

        /// <summary>
        /// Gets the sort command.
        /// </summary>
        public ICommand SortCommand { get; private set; }

        /// <summary>
        /// Gets the sorted collection of cards.
        /// </summary>
        public ListCollectionView SortedCards
        {
            get
            {
                return this.makeViewSource.View as ListCollectionView;
            }
        }

        /// <summary>
        /// Sorts all objects in the list by the column header clicked.
        /// </summary>
        /// <param name="parameter">The column header clicked.</param>
        public void Sort(object parameter)
        {
            string columnName = parameter as string;

            if (this.sortColumnName == columnName)
            {
                this.sortDirection = this.sortDirection == ListSortDirection.Ascending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
            }
            else
            {
                this.sortColumnName = columnName;
                this.sortDirection = ListSortDirection.Ascending;
            }

            this.makeViewSource.SortDescriptions.Clear();
            this.makeViewSource.SortDescriptions.Add(new SortDescription(this.sortColumnName, this.sortDirection));
            var list = this.makeViewSource.View.Cast<object>().ToList();
        }

        /// <summary>
        /// Creates the commands.
        /// </summary>
        protected override void CreateCommands()
        {
            // Add the button to search for the card
            this.Commands.Add(new CommandViewModel("Search", new DelegateCommand(p => this.SearchForCard())));
            this.Commands.Add(new CommandViewModel("Browse All Cards", new DelegateCommand(p => this.SearchAllCards())));
        }

        /// <summary>
        /// Restores the view source to all cards (return from search filter).
        /// </summary>
        private void SearchAllCards()
        {
            this.makeViewSource = new CollectionViewSource();
            this.makeViewSource.Source = this.Cards;
            this.SortCommand = new DelegateCommand(this.Sort);
            this.OnPropertyChanged("SortedCards");
        }

        /// <summary>
        /// Filters the view source to search for cards matching user input text.
        /// </summary>
        private void SearchForCard()
        {
            if (this.CardSearchTextBox != null && this.CardSearchTextBox != string.Empty)
            {
                // Search for the card
                string cardSearch = this.CardSearchTextBox;
                this.makeViewSource = new CollectionViewSource();
                this.makeViewSource.Source = this.GetCard;

                // If the card is not found tell the user or show the card
                if (this.GetCard.Count == 0)
                {
                    MessageBox.Show("Could not find card", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // Change the view to show the card that was searched
                    this.SortCommand = new DelegateCommand(this.Sort);
                    this.OnPropertyChanged("SortedCards");
                }
            }
            else
            {
                MessageBox.Show("Please enter a card name, it is case sensitive", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}