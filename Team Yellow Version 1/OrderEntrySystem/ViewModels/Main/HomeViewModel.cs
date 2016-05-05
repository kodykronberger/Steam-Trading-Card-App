using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using OrderEntryEngine;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent a home view model.
    /// </summary>
    public class HomeViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The news list.
        /// </summary>
        private List<News> news;

        /// <summary>
        /// The database repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="repository">The database repository.</param>
        public HomeViewModel(Repository repository)
            : base(" Home ")
        {
            this.repository = repository;
            this.MostRecent = new ObservableCollection<SinglePostViewModel>();
            this.InitializeMostRecent();
            this.repository.PostAdded += this.OnPostAdded;
            this.repository.PostDeleted += this.OnPostDeleted;
            this.CloseButtonVisibility = "Collapsed";
            this.OnPropertyChanged("CloseButtonVisibility");
            this.News = new List<News>(this.repository.GetNewsList());
        }

        /// <summary>
        /// Gets the observable collection of the most recently added single post view models.
        /// </summary>
        public ObservableCollection<SinglePostViewModel> MostRecent { get; private set; }

        /// <summary>
        /// Gets or sets the news.
        /// </summary>
        public List<News> News
        {
            get
            {
                return this.news as List<News>;
            }
            set
            {
                this.OnPropertyChanged("News");
                this.news = value;
            }
        }

        /// <summary>
        /// Creates the commands.
        /// </summary>
        protected override void CreateCommands()
        {
        }

        /// <summary>
        /// Initializes most recent posts on Home page.
        /// </summary>
        private void InitializeMostRecent()
        {
            List<GameViewModel> games = (from game in this.repository.GetGames()
                                         select new GameViewModel(game, this.repository)).ToList();
            List<CardViewModel> cards = (from card in this.repository.GetCards()
                                               select new CardViewModel(card, this.repository)).ToList();

            // Get a list of view models for each car in the repository.
            List<SinglePostViewModel> posts = (from post in this.repository.GetPosts()
                                               orderby post.DatePosted descending
                                               select new SinglePostViewModel(post, this.repository)).ToList();

            if (posts.Count() > 0)
            {
                // Create view model for newly-added post.
                SinglePostViewModel viewModel = new SinglePostViewModel(posts[0].Post, this.repository);

                // Add new view model to all cars list.
                this.MostRecent.Add(viewModel);
            }
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
            if (this.MostRecent != null)
            {
                this.MostRecent.Clear();
            }

            // Create view model for newly-added post.
            SinglePostViewModel viewModel = new SinglePostViewModel(e.Post, this.repository);

            // Add new view model to all cars list.
            this.MostRecent.Add(viewModel);
        }

        /// <summary>
        /// Clears the most recent post when a post is deleted (via blank object).
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The post event arguments.</param>
        private void OnPostDeleted(object sender, PostEventArgs e)
        {
            this.MostRecent = new ObservableCollection<SinglePostViewModel>();
        }
    }
}