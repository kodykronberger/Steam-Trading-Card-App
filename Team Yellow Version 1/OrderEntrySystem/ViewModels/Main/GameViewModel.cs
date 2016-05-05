using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderEntryEngine;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent a game view model.
    /// </summary>
    public class GameViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The database repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// The game view model's game.
        /// </summary>
        private Game game;

        /// <summary>
        /// The value indicating whether or not a game is selected.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="game">The game view model's game.</param>
        /// <param name="repository">The database repository.</param>
        public GameViewModel(Game game, Repository repository)
            : base("New Model")
        {
            this.game = game;
            this.repository = repository;
        }

        /// <summary>
        /// Gets the game view model's game.
        /// </summary>
        public Game Game
        {
            get
            {
                return this.game;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not a game is selected.
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
        /// Gets or sets the game's ID.
        /// </summary>
        public int Id
        {
            get
            {
                return this.game.Id;
            }
            set
            {
                this.game.Id = value;

                this.OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Gets or sets the title of the game.
        /// </summary>
        public string Title
        {
            get
            {
                return this.game.Title;
            }
            set
            {
                this.game.Title = value;

                this.OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// Creates the commands.
        /// </summary>
        protected override void CreateCommands()
        {
        }

        /// <summary>
        /// Executes on OK click in window.
        /// </summary>
        private void OkExecute()
        {
            // Save the model.
            this.Save();

            // Close the window.
            if (this.CloseAction != null)
            {
                this.CloseAction(true);
            }
        }

        /// <summary>
        /// Executes on Cancel click in window.
        /// </summary>
        private void CancelExecute()
        {
            if (this.CloseAction != null)
            {
                this.CloseAction(false);
            }
        }

        /// <summary>
        /// Saves the game model into the repository.
        /// </summary>
        private void Save()
        {
        }
    }
}