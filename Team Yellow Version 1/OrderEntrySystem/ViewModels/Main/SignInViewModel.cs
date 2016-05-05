using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json.Linq;
using OrderEntryEngine;
using OrderEntrySystem.Utilities;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent a sign-in/profile view model.
    /// </summary>
    public class SignInViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The user signed-in action.
        /// </summary>
        public Action UserHasSignedIn;

        /// <summary>
        /// Whether the commands template is visible.
        /// </summary>
        private string commandsVisibility;

        /// <summary>
        /// The database repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// The observable collection of command view models that provides notifications in the event of changes.
        /// </summary>
        private ObservableCollection<CommandViewModel> signInCommands = new ObservableCollection<CommandViewModel>();

        /// <summary>
        /// The text string inside of the steam id text box.
        /// </summary>
        private string steamIdTextBox;

        /// <summary>
        /// The current user's user name.
        /// </summary>
        private string userName;

        /// <summary>
        /// The observable collection of work space view models.
        /// </summary>
        private ObservableCollection<WorkspaceViewModel> workspaces;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="repository">The database repository.</param>
        public SignInViewModel(Repository repository)
            : base("Profile")
        {
            this.repository = repository;
            this.commandsVisibility = "Hidden";
            this.userName = "Not logged in.";
        }

        /// <summary>
        /// Gets the collection of posts.
        /// </summary>
        public ObservableCollection<SinglePostViewModel> AllPosts { get; private set; }

        /// <summary>
        /// Gets whether the commands template is visible.
        /// </summary>
        public string CommandsVisibility
        {
            get
            {
                return this.commandsVisibility;
            }
        }

        /// <summary>
        /// Gets the observable collection of the most recent single post view models.
        /// </summary>
        public ObservableCollection<SinglePostViewModel> MostRecent { get; private set; }

        /// <summary>
        /// Gets the collection of command view models.
        /// </summary>
        public ObservableCollection<CommandViewModel> SignInCommands
        {
            get
            {
                return this.signInCommands;
            }
        }

        /// <summary>
        /// Gets or sets the text string inside of the Steam ID text box.
        /// </summary>
        public string SteamIdTextBox
        {
            get
            {
                return this.steamIdTextBox;
            }

            set
            {
                this.steamIdTextBox = value;

                this.OnPropertyChanged("SteamIdTextBox");
            }
        }

        /// <summary>
        /// Gets or sets the collection of the current user's cards.
        /// </summary>
        public ObservableCollection<CardViewModel> UserCards { get; set; }

        /// <summary>
        /// Gets the current user's user name.
        /// </summary>
        public string UserName
        {
            get
            {
                return this.userName;
            }
        }

        /// <summary>
        /// Gets the workspace observable collection.
        /// </summary>
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                // Use lazy instantiation pattern to create upon first request.
                if (this.workspaces == null)
                {
                    this.workspaces = new ObservableCollection<WorkspaceViewModel>();
                }

                return this.workspaces;
            }
        }

        /// <summary>
        /// Creates a new post view.
        /// </summary>
        public void CreateNewPost()
        {
            // Create a post.
            Post post = new Post();

            // Create a view model for the post.
            AddNewPostViewModel workspace = new AddNewPostViewModel(post, this.repository);

            workspace.RequestClose += this.OnWorkspaceRequestClose;

            // Add the add post view model (workspace) to list.
            this.Workspaces.Add(workspace);

            // Move to the new tab (activate the view model).
            this.ActivateWorkspace(workspace);

            this.ShowPost(workspace);
        }

        /// <summary>
        /// Creates the commands.
        /// </summary>
        protected override void CreateCommands()
        {
            this.Commands.Add(new CommandViewModel("Add New Post", new DelegateCommand(p => this.CreateNewPost())));
            this.Commands.Add(new CommandViewModel("View Posts", new DelegateCommand(p => this.ShowAllPosts())));
            this.SignInCommands.Add(new CommandViewModel("Sign In", new DelegateCommand(p => this.SignIn())));
        }

        /// <summary>
        /// Activates the workspace.
        /// </summary>
        /// <param name="workspace">The workspace to be activated.</param>
        private void ActivateWorkspace(WorkspaceViewModel workspace)
        {
            // Get the view that is associated with the specified view model.
            ICollectionView view = CollectionViewSource.GetDefaultView(this.Workspaces);

            if (view != null)
            {
                // Make View current.
                view.MoveCurrentTo(workspace);
            }
        }

        /// <summary>
        /// Creates a list of cards as view models.
        /// </summary>
        /// <param name="steamId">The steamId to pull the cards for.</param>
        private void AddAllUserCards(string steamId)
        {
            // Get a list of view models for each card in the repository.
            IEnumerable<CardViewModel> cards =
                from card in this.repository.GetCards()
                select new CardViewModel(card, this.repository);

            // Create observable collection from the list.
            this.UserCards = new ObservableCollection<CardViewModel>();

            foreach (CardViewModel vm in cards)
            {
                foreach (Inventory inventory in vm.Card.Inventorys)
                {
                    if (inventory.User.SteamId == steamId)
                    {
                        this.UserCards.Add(vm);
                    }
                }
            }

            this.OnPropertyChanged("UserCards");
        }

        /// <summary>
        /// Creates a list of posts as view models.
        /// </summary>
        private void CreateAllPosts()
        {
            // Get a list of view models for each customer in the repository.
            IEnumerable<SinglePostViewModel> posts =
                from customer in this.repository.GetPosts()
                select new SinglePostViewModel(customer, this.repository);

            // Create observable collection from the list.
            this.AllPosts = new ObservableCollection<SinglePostViewModel>(posts);
        }

        /// <summary>
        /// Resets the most recent post when a post is added.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The post event arguments.</param>
        private void OnPostAdded(object sender, PostEventArgs e)
        {
            // Clear the recentList of previous contents.
            // (*Currently coded function to display only ONE most recent item).
            this.MostRecent.Clear();

            // Create view model for newly-added post.
            SinglePostViewModel viewModel = new SinglePostViewModel(e.Post, this.repository);

            // Add new view model to all cars list.
            this.MostRecent.Add(viewModel);
        }

        /// <summary>
        /// Removes the workspace when a request to close occurs.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            this.workspaces.Remove(sender as WorkspaceViewModel);
        }

        /// <summary>
        /// The action to show all posts in a workspace.
        /// </summary>
        private void ShowAllPosts()
        {
            // Try to find existing opened tab.
            MultiUserPostViewModel viewModel = this.Workspaces.FirstOrDefault(vm => vm is MultiUserPostViewModel) as MultiUserPostViewModel;

            // If tab was not yet loaded...
            if (viewModel == null)
            {
                // Create view model.
                viewModel = new MultiUserPostViewModel(this.repository, CurrentUser.UserSignedIn);

                // Display as tab.
                this.Workspaces.Add(viewModel);
            }

            // Fix for posts not showing.
            viewModel.CreatePostList();

            // Set focus to tab.
            this.ActivateWorkspace(viewModel);

            // Create and configure window.
            WorkspaceWindow window = new WorkspaceWindow();

            viewModel.CloseAction = b => window.DialogResult = b;

            // TODO: Use binding instead.
            window.Title = viewModel.DisplayName;
            window.Height = 480;
            window.Width = 500;

            // Create and configure view.
            MultiPostView view = new MultiPostView();
            view.DataContext = viewModel;

            // Embed the view in the window.
            window.Content = view;

            // Show window.
            window.ShowDialog();
        }

        /// <summary>
        /// Shows the post view model in the sign-in workspace.
        /// </summary>
        /// <param name="viewModel">The new post being shown.</param>
        private void ShowPost(AddNewPostViewModel viewModel)
        {
            // Create and configure window.
            WorkspaceWindow window = new WorkspaceWindow();

            viewModel.CloseAction = b => window.DialogResult = b;
            viewModel.CloseWindow += window.Close;

            // TODO: Use binding instead.
            window.Title = viewModel.DisplayName;
            window.Width = 550;
            window.Height = 590;
            window.ResizeMode = ResizeMode.NoResize;

            // Create and configure view.
            PostView view = new PostView();
            view.DataContext = viewModel;

            // Embed the view in the window.
            window.Content = view;

            // Show window.
            window.ShowDialog();
        }

        /// <summary>
        /// The sign-in method of the application.
        /// </summary>
        private void SignIn()
        {
            // Shows a window that displays loading messages.
            Notifications.ShowLoadingWindow("Signing in..");

            // THIS string sets the application that you want to pull inventory from
            // 730/2 --- CSGO
            // 753/6 --- All steam items
            string appid = "753/6";

            // Gets steam inventory in JSON format
            string steamId = this.SteamIdTextBox;

            // Test steam Id's to use in presentation:
            // 76561198096574144 Polltax
            // 76561198048361104 Kodyk
            // 76561197974590193 Japachu
            // 76561198068452835 nckroushs
            // 76561197996458173 Janet
            // 76561197960546232 Private profile

            // Abort mission if they did not enter a steam id.
            if (steamId == null || steamId == string.Empty || steamId.Length == 0)
            {
                Notifications.CloseLoadingWindow();
                MessageBox.Show("Please enter your steam id in the text field.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Retrieve data from API.
            string jsonUrl = "http://steamcommunity.com/profiles/" + steamId + "/inventory/json/" + appid;
            WebClient wc = new WebClient();
            wc.DownloadStringAsync(new Uri(jsonUrl));

            // Callback function that handles the API data.
            wc.DownloadStringCompleted += (wcSender, wcE) =>
            {
                string json = null;

                try
                {
                    json = wcE.Result;
                }
                catch (Exception)
                {
                    Notifications.CloseLoadingWindow();
                    MessageBox.Show("The server is unavailable right now. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // The JSON data.
                JObject jsonobj;

                // If there is no JSON to be parsed, throw an error.
                try
                {
                    jsonobj = JObject.Parse(json);
                }
                catch (Exception)
                {
                    Notifications.CloseLoadingWindow();
                    MessageBox.Show("Please enter a valid steam id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                try
                {
                    User user = this.repository.GetUserBySteamId(steamId);

                    // If the user signing in is new...
                    if (user == null)
                    {
                        // jsonobj_ListOfItems ends up to be a list of all the player's cards.
                        List<JToken> jsonobj_ListOfItems = jsonobj["rgDescriptions"].ToList();

                        // Creates a new user when logging in.
                        user = new User();
                        user.SteamId = steamId;
                        CurrentUser.UserSignedIn = user;
                        user.Username = CurrentUser.GetUsernameFromId(steamId);
                        this.repository.AddUser(user);

                        int numberOfCardsAdded = 0;

                        // For each card...
                        foreach (JToken child in jsonobj_ListOfItems)
                        {
                            numberOfCardsAdded++;

                            Inventory inventoryListing = new Inventory();
                            Card card = null;

                            // Checks if the card exists in the database, if so refer to it, if not then add it and THEN refer to it.
                            string cardName = child.First()["name"].ToString();
                            if (this.repository.GetCardByName(cardName) != null)
                            {
                                // Attach the card and the user to a new listing, and save it.
                                card = this.repository.GetCardByName(cardName);
                                inventoryListing.Card = card;
                                inventoryListing.User = user;
                            }
                            else
                            {
                                // Card was not found in database, so create it.
                                card = new Card();
                                card.Name = cardName;
                                card.ThumbnailUrl = @"http://cdn.steamcommunity.com/economy/image/" + child.First()["icon_url"].ToString();

                                // Card will start out false, there will be a check later to see if it is actually a trading card.
                                bool isTradingCard = false;
                                JArray item_tags = (JArray)child.First()["tags"];

                                // For each "tag" in the card, e.g. rarity, game, etc..
                                foreach (JToken tag in item_tags)
                                {
                                    // Handles the possible JSON objects that are assosicated with the card.
                                    switch (tag["category_name"].ToString())
                                    {
                                        case "Rarity":
                                            tag["name"].ToString();
                                            break;
                                        case "Game":
                                            Game game = this.repository.GetGameByTitle(tag["name"].ToString());

                                            if (game == null)
                                            {
                                                game = new Game();
                                                game.Title = tag["name"].ToString();
                                                this.repository.AddGame(game);
                                            }

                                            card.Game = game;
                                            break;
                                        case "Item Type":
                                            if (tag["name"].ToString().Contains("Trading Card"))
                                            {
                                                isTradingCard = true;
                                            }
                                            else
                                            {
                                                isTradingCard = false;
                                            }

                                            break;
                                    }
                                }

                                // If the items is a trading card...
                                if (isTradingCard)
                                {
                                    // Attach the card and the user to a new listing, and save it.
                                    inventoryListing.Card = card;
                                    inventoryListing.User = user;

                                    this.repository.AddCard(card);
                                    this.repository.SaveToDatabase();
                                }
                            }

                            // Adds link between card and user
                            this.repository.AddInventory(inventoryListing);
                        }
                    }

                    // If the user signing in is not new...
                    else
                    {
                        CurrentUser.UserSignedIn = user;

                        // Update user's name;
                        user.Username = CurrentUser.GetUsernameFromId(steamId);
                        this.AddAllUserCards(steamId);
                    }

                    this.repository.SaveToDatabase();
                    this.AddAllUserCards(steamId);
                    this.commandsVisibility = "Visible";
                    this.OnPropertyChanged("CommandsVisibility");
                    this.userName = CurrentUser.GetUsernameFromId(this.steamIdTextBox);
                    this.OnPropertyChanged("UserName");

                    // Gets user's profile picture.
                    BitmapImage bitmap = new BitmapImage();

                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(CurrentUser.GetUserImageFromId(this.steamIdTextBox), UriKind.Absolute);
                    bitmap.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                    bitmap.EndInit();
                    ImageSource bitmap2 = bitmap;
                    Image finalimage = new Image();
                    finalimage.Source = bitmap2;
                    Notifications.ShowDesktopAlert(
                        string.Format(this.userName + " signed in"),
                        string.Format("Welcome " + this.userName + "! Make a post or search other posts to get started."),
                        finalimage.Source);

                    if (this.UserHasSignedIn != null)
                    {
                        this.UserHasSignedIn();
                    }

                    // Get rid of the loading window.
                    Notifications.CloseLoadingWindow();
                }
                catch (Exception)
                {
                    Notifications.CloseLoadingWindow();
                    MessageBox.Show(
                        "Inventory could not be retrieved. Possible reasons:\n\nSteam servers may be down for maintenance.\nYour profile is not set to public.\nYou have not set up your profile.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }
        };
        }
    }
}