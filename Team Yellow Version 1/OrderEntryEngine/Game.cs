using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent a game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Gets or sets the game's ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the game.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Sets the display string for the game.
        /// </summary>
        /// <returns>The display string.</returns>
        public override string ToString()
        {
            return this.Title;
        }
    }
}