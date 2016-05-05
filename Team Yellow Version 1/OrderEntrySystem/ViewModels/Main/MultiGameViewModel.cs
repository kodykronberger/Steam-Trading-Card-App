using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using OrderEntryEngine;
using OrderEntrySystem.Utilities;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent a multi game view model.
    /// </summary>
    public class MultiGameViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// A value indicating whether the game is selected.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// The view source collection.
        /// </summary>
        private CollectionViewSource makeViewSource;

        /// <summary>
        /// The database repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// The save command.
        /// </summary>
        private ICommand saveCommand;

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
        public MultiGameViewModel(Repository repository)
            : base("View All Games")
        {
            this.repository = repository;
            this.makeViewSource = new CollectionViewSource();
            this.makeViewSource.Source = this.Games;
            this.SortCommand = new DelegateCommand(this.Sort);
        }

        /// <summary>
        /// Gets the view models for all games in the repository.
        /// </summary>
        public ObservableCollection<GameViewModel> Games
        {
            get
            {
                // Get a list of view models for each card in the repository.
                IEnumerable<GameViewModel> games =
                    from game in this.repository.GetGames()
                    orderby game.Title ascending
                    select new GameViewModel(game, this.repository);

                // Create observable collection from the list.
                return new ObservableCollection<GameViewModel>(games);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the game is selected.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;

                this.OnPropertyChanged("IsSelected");
            }
        }

        /// <summary>
        /// Gets the save command.
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                if (this.saveCommand == null)
                {
                    this.saveCommand = new DelegateCommand(p => this.Save());
                }

                return this.saveCommand;
            }
        }

        /// <summary>
        /// Gets the sort command.
        /// </summary>
        public ICommand SortCommand { get; private set; }

        /// <summary>
        /// Gets the sorted collection of games.
        /// </summary>
        public ListCollectionView SortedGames
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
        }

        /// <summary>
        /// Saves the game to the database.
        /// </summary>
        private void Save()
        {
        }
    }
}