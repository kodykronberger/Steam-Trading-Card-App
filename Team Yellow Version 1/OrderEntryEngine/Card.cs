using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent a card.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Card()
        {
        }

        /// <summary>
        /// Gets or sets the description of the card.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the card's ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the inventories that own the object.
        /// </summary>
        public virtual ICollection<Inventory> Inventorys { get; set; }

        /// <summary>
        /// Gets or sets the game for the card.
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Gets or sets the name of the card.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Thumbnail Url of the card.
        /// </summary>
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Sets the display string for the card.
        /// </summary>
        /// <returns>The display string to be used.</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}