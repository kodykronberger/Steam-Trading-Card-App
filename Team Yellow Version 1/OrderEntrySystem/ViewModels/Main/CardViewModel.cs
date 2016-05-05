using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OrderEntryEngine;
using OrderEntrySystem.Utilities;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent a card view model.
    /// </summary>
    public class CardViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The card view model's card.
        /// </summary>
        private Card card;

        /// <summary>
        /// A value indicating whether the post is selected.
        /// </summary>
        private bool isSelected;

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
        /// <param name="card">The card view model's card.</param>
        /// <param name="repository">The database repository.</param>
        public CardViewModel(Card card, Repository repository)
            : base(" ")
        {
            this.card = card;
            this.repository = repository;
        }

        /// <summary>
        /// Gets or sets the view model's card.
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
        /// Gets or sets the card's ID.
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
        /// Gets or sets a value indicating whether the card is selected.
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
        /// Gets or sets the card's Game.
        /// </summary>
        public string Game
        {
            get
            {
                return this.card.Game.Title;
            }
            set
            {
                this.card.Game.Title = value;
                this.OnPropertyChanged("Game");
            }
        }

        /// <summary>
        /// Gets or sets the card's ID.
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
        /// Gets the card's thumbnail image.
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
        /// Creates the commands.
        /// </summary>
        protected override void CreateCommands()
        {
        }

        /// <summary>
        /// Saves the card to the database repository.
        /// </summary>
        private void Save()
        {
            this.repository.AddCard(this.card);
            this.repository.SaveToDatabase();
        }
    }
}