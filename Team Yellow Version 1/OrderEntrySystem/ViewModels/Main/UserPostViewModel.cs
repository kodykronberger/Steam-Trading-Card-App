using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OrderEntryEngine;
using OrderEntrySystem.Utilities;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent the individual view model of a user's post.
    /// </summary>
    public class UserPostViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The filtered post view model.
        /// </summary>
        private MultiUserPostViewModel filteredPostViewModel;

        /// <summary>
        /// A value indicating whether the post is selected.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// The current user's post.
        /// </summary>
        private Post post;

        /// <summary>
        /// The database repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// The save command.
        /// </summary>
        private ICommand saveCommand;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="post">The user's post.</param>
        /// <param name="repository">The database repository.</param>
        public UserPostViewModel(Post post, Repository repository)
            : base("Add User Post")
        {
            this.post = post;
            this.repository = repository;

            // Clear the commands
            this.Commands.Clear();
            this.CreateCommands();
            this.filteredPostViewModel = new MultiUserPostViewModel(this.repository, this.repository.GetUser(this.post.Id));
            this.filteredPostViewModel.AllPosts = this.FilteredPosts;
        }

        /// <summary>
        /// Gets or sets the post's card to offer.
        /// </summary>
        public Card CardToHave
        {
            get
            {
                return this.post.CardToHave;
            }
            set
            {
                this.post.CardToHave = value;
                this.OnPropertyChanged("CardToHave");
            }
        }

        /// <summary>
        /// Gets or sets the post's card to request.
        /// </summary>
        public Card CardToWant
        {
            get
            {
                return this.post.CardToWant;
            }
            set
            {
                this.post.CardToWant = value;
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
        /// Gets a collection of single post view models for the user.
        /// </summary>
        public ObservableCollection<SinglePostViewModel> FilteredPosts
        {
            get
            {
                ObservableCollection<SinglePostViewModel> result = new ObservableCollection<SinglePostViewModel>();

                foreach (Post cm in this.repository.GetPosts())
                {
                    SinglePostViewModel vm = new SinglePostViewModel(cm, this.repository);

                    result.Add(vm);
                }
                return result;
            }
        }

        /// <summary>
        /// Gets the multi-post view model filtered for the current user.
        /// </summary>
        public MultiUserPostViewModel FilteredPostViewModel
        {
            get
            {
                return this.filteredPostViewModel;
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
        /// Gets or sets a value indicating whether the post is selected.
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
        /// Creates the commands.
        /// </summary>
        protected override void CreateCommands()
        {
        }

        /// <summary>
        /// The save command.
        /// </summary>
        private void Save()
        {
            this.post.DatePosted = DateTime.Now;
            this.repository.AddPost(this.post);
            this.repository.SaveToDatabase();
        }
    }
}