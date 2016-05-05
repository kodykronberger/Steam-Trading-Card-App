using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using OrderEntryEngine;
using OrderEntrySystem.Utilities;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent an add new post view model.
    /// </summary>
    public class AddNewPostViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The window close action.
        /// </summary>
        public Action CloseWindow;

        /// <summary>
        /// The post's card to offer.
        /// </summary>
        private CardViewModel cardToHave;

        /// <summary>
        /// The post's card to request.
        /// </summary>
        private CardViewModel cardToWant;

        /// <summary>
        /// The new post being created.
        /// </summary>
        private Post post;

        /// <summary>
        /// The database repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// The save command delegate.
        /// </summary>
        private ICommand saveCommand;

        /// <summary>
        /// The game selected from the all games (request) list.
        /// </summary>
        private string selectedGame;

        /// <summary>
        /// The game selected from the user's game (offer) list.
        /// </summary>
        private string selectedUserGame;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="post">The new post being created.</param>
        /// <param name="repository">The database repository.</param>
        public AddNewPostViewModel(Post post, Repository repository)
            : base("Add New Post")
        {
            this.post = post;
            this.repository = repository;
            this.post.User = CurrentUser.UserSignedIn;
            this.UserCardsSorted = new ObservableCollection<CardViewModel>(this.AllUserCards);
            this.CardsSorted = new ObservableCollection<CardViewModel>(this.AllCards);
            this.SelectedGame = this.AllGames[0];
            this.SelectedUserGame = this.AllGames[0];
        }

        /// <summary>
        /// Gets the view models for all cards in the repository.
        /// </summary>
        public ObservableCollection<CardViewModel> AllCards
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
        /// Gets the title strings for all games in the repository.
        /// </summary>
        public ObservableCollection<string> AllGames
        {
            get
            {
                // Get a list of view models for each card in the repository.
                IEnumerable<string> games =
                    from game in this.repository.GetGames()
                    orderby game.Title ascending
                    select game.Title;

                // Create observable collection from the list.
                ObservableCollection<string> gameCollection = new ObservableCollection<string>(games);
                gameCollection.Insert(0, "All Games");
                return gameCollection;
            }
        }

        /// <summary>
        /// Gets the view models for all the cards in the user's inventory.
        /// </summary>
        public ObservableCollection<CardViewModel> AllUserCards
        {
            get
            {
                // Get a list of view models for each card in the repository.
                IEnumerable<CardViewModel> cards =
                    from card in this.repository.GetCards()
                    select new CardViewModel(card, this.repository);

                // Create observable collection from the list.
                var result = new ObservableCollection<CardViewModel>();

                foreach (CardViewModel vm in cards)
                {
                    foreach (Inventory inventory in vm.Card.Inventorys)
                    {
                        if (inventory.User.SteamId == CurrentUser.UserSignedIn.SteamId)
                        {
                            result.Add(vm);
                        }
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets or sets the observable collection of sorted card view models.
        /// </summary>
        public ObservableCollection<CardViewModel> CardsSorted { get; set; }

        /// <summary>
        /// Gets or sets the post's card to offer.
        /// </summary>
        public CardViewModel CardToHave
        {
            get
            {
                return this.cardToHave;
            }
            set
            {
                this.cardToHave = value;
                this.post.CardToHave = this.CardToHave.Card;
                this.OnPropertyChanged("CardToHave");
            }
        }

        /// <summary>
        /// Gets or sets the post's card to request.
        /// </summary>
        public CardViewModel CardToWant
        {
            get
            {
                return this.cardToWant;
            }
            set
            {
                this.cardToWant = value;
                this.post.CardToWant = this.CardToWant.Card;
                this.OnPropertyChanged("CardToWant");
            }
        }

        /// <summary>
        /// Gets or sets the post's description.
        /// </summary>
        public string Description
        {
            get
            {
                return this.post.Description;
            }
            set
            {
                this.post.Description = value;

                this.OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets and returns an enumerable list of game title enumerations.
        /// </summary>
        public IEnumerable<GameEnum> Games
        {
            get
            {
                IEnumerable<GameEnum> values = Enum.GetValues(typeof(GameEnum)) as IEnumerable<GameEnum>;

                return values.OrderBy(c => c.ToString());
            }
        }

        /// <summary>
        /// Gets or sets the post's ID.
        /// </summary>
        public int Id
        {
            get
            {
                return this.post.Id;
            }
            set
            {
                this.post.Id = value;

                this.OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Gets or sets the enumeration list of game titles.
        /// </summary>
        public GameEnum ListOfGame
        {
            get
            {
                return this.post.ListOfGame;
            }
            set
            {
                this.post.ListOfGame = value;
                this.OnPropertyChanged("ListOfGame");
            }
        }

        /// <summary>
        /// Gets the save command delegate.
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
        /// Gets or sets the game selected.
        /// </summary>
        public string SelectedGame
        {
            get
            {
                return this.selectedGame;
            }
            set
            {
                this.selectedGame = value;

                if (this.selectedGame == "All Games")
                {
                    this.CardsSorted = new ObservableCollection<CardViewModel>();

                    // For each card in all user cards..
                    foreach (CardViewModel vm in this.AllCards)
                    {
                        this.CardsSorted.Add(vm);
                    }
                }
                else
                {
                    // Create new collection blank.
                    this.CardsSorted = new ObservableCollection<CardViewModel>();

                    // For each card in all user cards, if card game title equals the one selected, show it.
                    foreach (CardViewModel vm in this.AllCards)
                    {
                        if (vm.Card.Game.Title == this.selectedGame)
                        {
                            this.CardsSorted.Add(vm);
                        }
                    }
                }

                this.OnPropertyChanged("SelectedGame");
                this.OnPropertyChanged("CardsSorted");
            }
        }

        /// <summary>
        /// Gets or sets the selected user's game.
        /// </summary>
        public string SelectedUserGame
        {
            get
            {
                return this.selectedUserGame;
            }
            set
            {
                this.selectedUserGame = value;

                if (this.selectedUserGame == "All Games")
                {
                    this.UserCardsSorted = new ObservableCollection<CardViewModel>();

                    // For each card in all user cards..
                    foreach (CardViewModel vm in this.AllUserCards)
                    {
                        this.UserCardsSorted.Add(vm);
                    }
                }
                else
                {
                    // Create new blank collection.
                    this.UserCardsSorted = new ObservableCollection<CardViewModel>();

                    // For each card in all user cards, if card game title equals the one selected, show it.
                    foreach (CardViewModel vm in this.AllUserCards)
                    {
                        if (vm.Card.Game.Title == this.selectedUserGame)
                        {
                            this.UserCardsSorted.Add(vm);
                        }
                    }
                }

                this.OnPropertyChanged("SelectedUserGame");
                this.OnPropertyChanged("UserCardsSorted");
            }
        }

        /// <summary>
        /// Gets the current user.
        /// </summary>
        public User User
        {
            get
            {
                return this.post.User;
            }
        }

        /// <summary>
        /// Gets or sets the observable collection of sorted card view models filtered to the current user.
        /// </summary>
        public ObservableCollection<CardViewModel> UserCardsSorted { get; set; }

        /// <summary>
        /// Creates the commands.
        /// </summary>
        protected override void CreateCommands()
        {
        }

        /// <summary>
        /// Saves the post to the database repository.
        /// </summary>
        private void Save()
        {
            this.post.DatePosted = DateTime.Now;

            // Add car to repository.
            this.repository.AddPost(this.post);

            this.repository.SaveToDatabase();

            MessageBox.Show("Post Added Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            this.CloseWindow();
        }
    }
}