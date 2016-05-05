using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OrderEntryEngine;
using OrderEntrySystem.Utilities;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The single post view model which implements the workspace view model.
    /// </summary>
    public class SinglePostViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// A value indicating whether the post is selected.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// The single post view model's post.
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
        /// <param name="post">The single post view model's post.</param>
        /// <param name="repository">The database repository.</param>
        public SinglePostViewModel(Post post, Repository repository)
            : base(" ")
        {
            this.post = post;
            this.repository = repository;
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
        /// Gets the game title of the post's card to offer.
        /// </summary>
        public string CardToHaveGame
        {
            get
            {
                return this.post.CardToHave.Game.Title;
            }
        }

        /// <summary>
        /// Gets the name string of the post's card to offer.
        /// </summary>
        public string CardToHaveName
        {
            get
            {
                return this.post.CardToHave.Name;
            }
        }

        /// <summary>
        /// Gets the post's card to offer thumbnail image.
        /// </summary>
        public ImageSource CardToHaveThumbnail
        {
            get
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(this.CardToHave.ThumbnailUrl, UriKind.Absolute);
                bitmap.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                bitmap.EndInit();
                ImageSource bitmap2 = bitmap;
                Image finalimage = new Image();
                finalimage.Source = bitmap2;
                return finalimage.Source;
            }
        }

        /// <summary>
        /// Gets or sets post's card to request.
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
        /// Gets the game string of the post's card to request.
        /// </summary>
        public string CardToWantGame
        {
            get
            {
                return this.post.CardToWant.Game.Title;
            }
        }

        /// <summary>
        /// Gets the name string of post's card to request.
        /// </summary>
        public string CardToWantName
        {
            get
            {
                return this.post.CardToWant.Name;
            }
        }

        /// <summary>
        /// Gets the thumbnail image of the post's card to request.
        /// </summary>
        public ImageSource CardToWantThumbnail
        {
            get
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(this.CardToWant.ThumbnailUrl, UriKind.Absolute);
                bitmap.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                bitmap.EndInit();
                ImageSource bitmap2 = bitmap;
                Image finalimage = new Image();
                finalimage.Source = bitmap2;
                return finalimage.Source;
            }
        }

        /// <summary>
        /// Gets the post's date posted.
        /// </summary>
        public DateTime DatePosted
        {
            get
            {
                return this.post.DatePosted;
            }
        }

        /// <summary>
        /// Gets or sets description of the post.
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
        /// Gets the Post object in the view model.
        /// </summary>
        public Post Post
        {
            get
            {
                return this.post;
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
        /// Gets the current user's user name.
        /// </summary>
        public string UserName
        {
            get
            {
                return this.post.User.Username;
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
            this.repository.AddPost(this.post);

            this.repository.SaveToDatabase();
        }
    }
}