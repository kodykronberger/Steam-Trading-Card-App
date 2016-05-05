using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent the card as an event argument.
    /// </summary>
    public class GameEventArgs
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="game">The game for which the event occurs.</param>
        public GameEventArgs(Game game)
        {
            this.GameItem = game;
        }

        /// <summary>
        /// Gets the game object of the event.
        /// </summary>
        public Game GameItem { get; private set; }
    }
}