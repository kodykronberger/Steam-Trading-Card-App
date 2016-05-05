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
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;

namespace OrderEntrySystem
{
    /// <summary>
    /// The single post view model which implements the workspace view model.
    /// </summary>
    public class MiniCardViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The new post to be created. NOTE: change 'object' to Post once class created.
        /// </summary>
        private Card card;

        /// <summary>
        /// The database repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// The save command interface.
        /// </summary>
        private ICommand saveCommand;

        /// <summary>
        /// A value indicating whether the post is selected.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="post">The new post being created.</param>
        /// <param name="repository">The database repository.</param>
        public MiniCardViewModel(Card card, Repository repository)
            : base(" ")
        {
            this.card = card;
            this.repository = repository;
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
        /// Gets or sets the card.
        /// </summary>
        public Card Card
        {
            get
            {
                return this.card;
            }

            set
            {
                this.card = value;
            }
        }

        /// <summary>
        /// Gets or sets the post's ID.
        /// </summary>
        public int Id
        {
            get
            {
                return this.card.Id;
            }
            set
            {
                this.card.Id = value;
                this.OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Gets or sets the post's ID.
        /// </summary>
        public string Name
        {
            get
            {
                return this.card.Name;
            }
            set
            {
                this.card.Name = value;
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the post's Game.
        /// </summary>
        public string Game
        {
            get
            {
                return this.card.Game;
            }
            set
            {
                this.card.Game = value;
                this.OnPropertyChanged("Game");
            }
        }

        /// <summary>
        /// Gets or sets the post's Thumbnail.
        /// </summary>
        public ImageSource Thumbnail
        {
            get
            {
                BitmapImage bitmap = new BitmapImage();

                bitmap.BeginInit();
                bitmap.UriSource = new Uri(this.card.ThumbnailUrl, UriKind.Absolute);
                bitmap.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                bitmap.EndInit();

                ImageSource bitmap2 = bitmap;
                Image finalimage = new Image();
                finalimage.Source = bitmap2;

                return finalimage.Source;
            }
        }

        /// <summary>
        /// Gets the save command
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
        /// This is the save command
        /// </summary>
        private void Save()
        {
            this.repository.AddCard(this.card);

            this.repository.SaveToDatabase();
        }
    }
}