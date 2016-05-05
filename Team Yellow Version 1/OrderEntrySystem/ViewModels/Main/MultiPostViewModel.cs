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
    /// The class which is used to represent a multi-post view model.
    /// </summary>
    public class MultiPostViewModel : WorkspaceViewModel
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
        public MultiPostViewModel(Repository repository, User user)
            : base("View Posts")
        {
            // Clear the commands
            this.Commands.Clear();
            this.CreateCommands();
            this.repository = repository;
            this.DisplayedPosts = new ObservableCollection<SinglePostViewModel>();
            this.user = user;

            // Get a list of view models for each car in the repository.
            List<SinglePostViewModel> posts = (from post in this.repository.GetPosts()
                                               orderby post.DatePosted descending
                                               select new SinglePostViewModel(post, this.repository)).ToList();

            this.AllPosts = new ObservableCollection<SinglePostViewModel>(posts);
            this.repository.PostAdded += this.OnPostAdded;
            this.repository.PostDeleted += this.OnPostDeleted;
            this.Pager = new PagingViewModel(this.AllPosts.Count);
            this.Pager.CurrentPageChanged += this.OnPageChange;
            this.RebuildPageData();
        }

        /// <summary>
        /// Gets the observable collection of all single post view models.
        /// </summary>
        public ObservableCollection<SinglePostViewModel> AllPosts { get; private set; }

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
        /// Rebuilds the page data.
        /// </summary>
        public void RebuildPageData()
        {
            this.DisplayedPosts.Clear();
            int startingIndex = this.Pager.PageSize * (this.Pager.CurrentPage - 1);
            List<SinglePostViewModel> displayedModels = this.AllPosts.Skip(startingIndex).Take(this.Pager.PageSize).ToList();
            this.Pager.ItemCount = this.AllPosts.Count;

            foreach (SinglePostViewModel vm in displayedModels)
            {
                this.DisplayedPosts.Add(vm);
            }
        }

        /// <summary>
        /// Creates the commands.
        /// </summary>
        protected override void CreateCommands()
        {
            if (CurrentUser.UserSignedIn != null)
            {
                this.Commands.Add(new CommandViewModel("Reply to Post", new DelegateCommand(p => this.ReplyToPost())));
            }
        }

        /// <summary>
        /// Confirms the reply to post.
        /// </summary>
        /// <param name="viewModel">The selected view model of post to reply to.</param>
        private void ConfirmReply(SinglePostViewModel viewModel)
        {
            if (MessageBox.Show("Do you want to trade on this offer?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Trade Successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.repository.RemovePost(viewModel.Post);
                this.repository.SaveToDatabase();
            }

            this.OnPropertyChanged("AllPosts");
        }

        /// <summary>
        /// Edit the post selected.
        /// </summary>
        private void EditPost()
        {
            SinglePostViewModel viewModel = this.AllPosts.FirstOrDefault(vm => vm.IsSelected);

            if (viewModel != null)
            {
                this.ShowPost(viewModel);
            }
            else
            {
                MessageBox.Show("Please select a Post", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.OnPropertyChanged("AllPosts");
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
            this.AllPosts.Insert(0, viewModel);
            this.RebuildPageData();
        }

        /// <summary>
        /// Rebuilds the page data when the page is changed.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event argument</param>
        private void OnPageChange(object sender, CurrentPageChangedEventArgs e)
        {
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
        /// Replies to the post selected.
        /// </summary>
        private void ReplyToPost()
        {
            SinglePostViewModel viewModel = this.AllPosts.FirstOrDefault(vm => vm.IsSelected);

            if (viewModel != null)
            {
                if (viewModel.UserName != this.user.Username)
                {
                    this.ConfirmReply(viewModel);
                }
                else
                {
                    MessageBox.Show("Please select another user's post.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a Post", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Shows a single post in the multi-view.
        /// </summary>
        /// <param name="viewModel">The view model for the post.</param>
        private void ShowPost(SinglePostViewModel viewModel)
        {
            // Create the window
            WorkspaceWindow window = new WorkspaceWindow();
            window.Title = viewModel.DisplayName;
            window.ResizeMode = ResizeMode.NoResize;

            viewModel.CloseAction = b => window.DialogResult = b;

            // Create the view
            PostView view = new PostView();
            view.DataContext = viewModel;

            // Embed the view in the window
            window.Content = view;

            // Show the window
            window.ShowDialog();
        }
    }
}