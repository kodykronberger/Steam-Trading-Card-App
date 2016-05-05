using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OrderEntryEngine;
using OrderEntrySystem.Utilities;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent the user-filtered multiple posts view model.
    /// </summary>
    public class MultiUserPostViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The database repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// The current user.
        /// </summary>
        private User user;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="repository">The database repository.</param>
        /// <param name="user">The current user.</param>
        public MultiUserPostViewModel(Repository repository, User user)
            : base("View Posts")
        {
            // Clear the commands
            this.Commands.Clear();
            this.CreateCommands();
            this.repository = repository;
            this.DisplayedPosts = new ObservableCollection<SinglePostViewModel>();
            this.user = user;

            // Get a list of view models for each car in the repository.
            this.CreatePostList();
            this.Pager = new PagingViewModel(this.AllPosts.Count);
            this.Pager.CurrentPageChanged += this.OnPageChange;
            this.RebuildPageData();
        }

        /// <summary>
        /// Gets or sets the observable collection of all single post view models.
        /// </summary>
        public ObservableCollection<SinglePostViewModel> AllPosts { get; set; }

        /// <summary>
        /// Gets the collection of posts.
        /// </summary>
        public ObservableCollection<SinglePostViewModel> DisplayedPosts { get; private set; }

        /// <summary>
        /// Gets or sets the number of posts selected.
        /// </summary>
        public int NumberOfPostsSelected { get; set; }

        /// <summary>
        /// Gets the pager.
        /// </summary>
        public PagingViewModel Pager { get; private set; }

        /// <summary>
        /// Re-Creates the post list.
        /// </summary>
        public void CreatePostList()
        {
            List<SinglePostViewModel> posts = (from post in this.repository.GetPosts()
                                               where post.User.SteamId == CurrentUser.UserSignedIn.SteamId
                                               orderby post.DatePosted descending
                                               select new SinglePostViewModel(post, this.repository)).ToList();

            this.AllPosts = new ObservableCollection<SinglePostViewModel>(posts);
            this.repository.PostAdded += this.OnPostAdded;
            this.repository.PostDeleted += this.OnPostDeleted;
        }

        /// <summary>
        /// Rebuilds the page data.
        /// </summary>
        public void RebuildPageData()
        {
            this.DisplayedPosts.Clear();
            int startingIndex = this.Pager.PageSize * (this.Pager.CurrentPage - 1);
            List<SinglePostViewModel> displayedUserModels = this.AllPosts.Skip(startingIndex).Take(this.Pager.PageSize).ToList();
            this.Pager.ItemCount = this.AllPosts.Count;

            foreach (SinglePostViewModel vm in displayedUserModels)
            {
                this.DisplayedPosts.Add(vm);

                MessageBox.Show("Please select a Post", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Creates the commands.
        /// </summary>
        protected override void CreateCommands()
        {
                this.Commands.Add(new CommandViewModel("Edit Post", new DelegateCommand(p => this.EditPost())));
                this.Commands.Add(new CommandViewModel("Delete Post", new DelegateCommand(p => this.DeletePost())));
        }

        /// <summary>
        /// Delete the post selected.
        /// </summary>
        private void DeletePost()
        {
            SinglePostViewModel viewModel = this.DisplayedPosts.FirstOrDefault(vm => vm.IsSelected);

            if (viewModel != null)
            {
                if (MessageBox.Show("Are you sure that you want to delete this post?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    this.repository.RemovePost(viewModel.Post);
                    this.repository.SaveToDatabase();
                }
            }
            else
            {
                MessageBox.Show("Please select a Post", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.OnPropertyChanged("AllPosts");
        }

        /// <summary>
        /// Edit the post selected.
        /// </summary>
        private void EditPost()
        {
            SinglePostViewModel viewModel = this.DisplayedPosts.FirstOrDefault(vm => vm.IsSelected);

            if (viewModel != null)
            {
                this.CreatePostList();
                this.repository.SaveToDatabase();
                this.ShowPost(viewModel);
            }
            else
            {
                MessageBox.Show("Please select a Post");
            }

            this.OnPropertyChanged("AllPosts");
        }

        /// <summary>
        /// Rebuilds the page data when the current page is changed.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event argument</param>
        private void OnPageChange(object sender, CurrentPageChangedEventArgs e)
        {
            this.RebuildPageData();
        }

        /// <summary>
        /// Rebuilds the page data when a post is added.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The post event arguments.</param>
        private void OnPostAdded(object sender, PostEventArgs e)
        {
            // Create view model for newly-added car.
            SinglePostViewModel viewModel = new SinglePostViewModel(e.Post, this.repository);

            // Add new view model to all cars list.
            this.AllPosts.Add(viewModel);
            this.RebuildPageData();
        }

        /// <summary>
        /// Rebuilds the page data when a post is deleted.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The post event arguments.</param>
        private void OnPostDeleted(object sender, PostEventArgs e)
        {
            foreach (SinglePostViewModel vm in this.AllPosts)
            {
                if (vm.Post == e.Post)
                {
                    this.AllPosts.Remove(vm);
                    this.RebuildPageData();
                    return;
                }
            }
        }

        /// <summary>
        /// Rebuilds the page data when a post is edited.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The post event arguments.</param>
        private void OnPostEdited(object sender, PostEventArgs e)
        {
            // Create view model for newly-added car.
            SinglePostViewModel viewModel = new SinglePostViewModel(e.Post, this.repository);

            // Add new view model to all cars list.
            foreach (SinglePostViewModel vm in this.AllPosts)
            {
                if (vm.Post == viewModel.Post)
                {
                    this.AllPosts.Remove(vm);
                    this.RebuildPageData();
                }
            }

            this.AllPosts.Add(viewModel);

            this.OnPropertyChanged("AllPosts");
        }

        /// <summary>
        /// Shows a single post in the multi-view.
        /// </summary>
        /// <param name="viewModel">The view model for the post.</param>
        private void ShowPost(SinglePostViewModel viewModel)
        {
            // Create the window
            WorkspaceWindow window = new WorkspaceWindow();
            window.Title = "Edit Post";
            window.Width = 550;
            window.Height = 590;
            window.ResizeMode = ResizeMode.NoResize;

            // Creates a new view model for the post.
            AddNewPostViewModel viewModel2 = new AddNewPostViewModel(viewModel.Post, this.repository);
            viewModel2.CloseWindow += window.Close;

            // Create the view
            PostView view = new PostView();
            view.DataContext = viewModel2;

            // Embed the view in the window
            window.Content = view;

            // Show the window
            window.ShowDialog();

            if (window.DialogResult == true)
            {
                this.OnPostEdited(this, new PostEventArgs(this.repository.GetPost(viewModel2.Id)));
            }
        }
    }
}