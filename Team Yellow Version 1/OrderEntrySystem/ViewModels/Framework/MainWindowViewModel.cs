using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using OrderEntryEngine;
using OrderEntrySystem;
using OrderEntrySystem.Utilities;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The main window view model which implements the workspace view model.
    /// </summary>
    public class MainWindowViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The database repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// The observable collection of work space view models.
        /// </summary>
        private ObservableCollection<WorkspaceViewModel> workspaces;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MainWindowViewModel()
            : base("Steam Trading")
        {
            this.repository = new Repository();

            this.CreateHome();
        }

        /// <summary>
        /// Gets the observable collection of workspace view models.
        /// </summary>
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                // Use the lazy instantiation pattern to create upon first request.
                if (this.workspaces == null)
                {
                    this.workspaces = new ObservableCollection<WorkspaceViewModel>();
                }

                return this.workspaces;
            }
        }

        /// <summary>
        /// Creates the browse all cards view.
        /// </summary>
        public void CreateBrowseAllCards()
        {
            // Try to find existing opened tab.
            BrowseAllCardsViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is BrowseAllCardsViewModel) as BrowseAllCardsViewModel;

            // If tab was not yet loaded...
            if (workspace == null)
            {
                // Create view model.
                workspace = new BrowseAllCardsViewModel(this.repository);
                workspace.RequestClose += this.OnWorkspaceRequestClose;

                // Display as tab.
                this.Workspaces.Add(workspace);
            }

            // Set focus to tab.
            this.ActivateWorkspace(workspace);
        }

        /// <summary>
        /// Creates the browse all games view.
        /// </summary>
        public void CreateBrowseAllGames()
        {
            // Try to find existing opened tab.
            BrowseAllGamesViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is BrowseAllGamesViewModel) as BrowseAllGamesViewModel;

            // If tab was not yet loaded...
            if (workspace == null)
            {
                // Create view model.
                workspace = new BrowseAllGamesViewModel(this.repository);
                workspace.RequestClose += this.OnWorkspaceRequestClose;

                // Display as tab.
                this.Workspaces.Add(workspace);
            }

            // Set focus to tab.
            this.ActivateWorkspace(workspace);
        }

        /// <summary>
        /// Creates the home view.
        /// </summary>
        public void CreateHome()
        {
            // Try to find existing opened tab.
            HomeViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is HomeViewModel) as HomeViewModel;

            // If tab was not yet loaded.
            if (workspace == null)
            {
                // Create view model.
                workspace = new HomeViewModel(this.repository);

                // Display as tab.
                this.Workspaces.Add(workspace);
            }

            // Set focus to tab.
            this.ActivateWorkspace(workspace);
        }

        /// <summary>
        /// Creates the multi games view.
        /// </summary>
        public void CreateNewGames()
        {
            // Try to find existing opened tab.
            MultiGameViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is MultiGameViewModel) as MultiGameViewModel;

            // If tab was not yet loaded...
            if (workspace == null)
            {
                // Create view model.
                workspace = new MultiGameViewModel(this.repository);
                workspace.RequestClose += this.OnWorkspaceRequestClose;

                // Display as tab.
                this.Workspaces.Add(workspace);
            }

            // Set focus to tab.
            this.ActivateWorkspace(workspace);
        }

        /// <summary>
        /// Creates the new post view.
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
        }

        /// <summary>
        /// Creates the search posts view.
        /// </summary>
        public void CreateSearchPosts()
        {
            // Create a view model for the search post.
            SearchPostsViewModel workspace = new SearchPostsViewModel(this.repository);

            workspace.RequestClose += this.OnWorkspaceRequestClose;

            // Add the search post view model (workspace) to list.
            this.Workspaces.Add(workspace);

            // Move to the new tab (activate the view model).
            this.ActivateWorkspace(workspace);
        }

        /// <summary>
        /// Creates the sign in view.
        /// </summary>
        public void CreateSignIn()
        {
            // Try to find existing opened tab.
            SignInViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is SignInViewModel) as SignInViewModel;

            // If tab was not yet loaded...
            if (workspace == null)
            {
                // Create view model.
                workspace = new SignInViewModel(this.repository);
                workspace.RequestClose += this.OnWorkspaceRequestClose;
                workspace.UserHasSignedIn += this.OnWorkspaceSignIn;

                // Display as tab.
                this.Workspaces.Add(workspace);
            }

            // Set focus to tab.
            this.ActivateWorkspace(workspace);
        }

        /// <summary>
        /// Shows a display message for commands which haven't been implemented.
        /// </summary>
        public void ShowNoViewMessage()
        {
            MessageBox.Show("Coming soon..", "Coming Soon", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Creates the commands.
        /// </summary>
        protected override void CreateCommands()
        {
            this.Commands.Add(new CommandViewModel("Home", new DelegateCommand(p => this.CreateHome())));
            this.Commands.Add(new CommandViewModel("View all Posts", new DelegateCommand(p => this.ShowAllPosts())));
            this.Commands.Add(new CommandViewModel("Browse All Cards", new DelegateCommand(p => this.CreateBrowseAllCards())));
            this.Commands.Add(new CommandViewModel("Browse All Games", new DelegateCommand(p => this.CreateNewGames())));
            this.Commands.Add(new CommandViewModel("Sign In", new DelegateCommand(p => this.CreateSignIn())));
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
        /// Closes the workspace on request.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            this.workspaces.Remove(sender as WorkspaceViewModel);
        }

        /// <summary>
        /// Switches to profile on user sign-in.
        /// </summary>
        private void OnWorkspaceSignIn()
        {
            CommandViewModel vm = this.Commands.FirstOrDefault(p => p.DisplayName == "Sign In");
            this.Commands.Remove(vm);
            this.Commands.Add(new CommandViewModel("My Profile", new DelegateCommand(p => this.CreateSignIn())));
            this.OnPropertyChanged("Commands");
        }

        /// <summary>
        /// Shows all posts in a workspace.
        /// </summary>
        private void ShowAllPosts()
        {
            if (CurrentUser.UserSignedIn == null)
            {
                if (MessageBox.Show("Only signed in users can see posts. Would you like to sign in now?", "Error", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    this.CreateSignIn();
                }
            }
            else
            {
                // Try to find existing opened tab.
                MultiPostViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is MultiPostViewModel) as MultiPostViewModel;

                // If tab was not yet loaded...
                if (workspace == null)
                {
                    // Create view model.
                    workspace = new MultiPostViewModel(this.repository, CurrentUser.UserSignedIn);
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

                    // Display as tab.
                    this.Workspaces.Add(workspace);
                }

                // Set focus to tab.
                this.ActivateWorkspace(workspace);
            }
        }
    }
}