using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent the users' card inventory listings.
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Gets or sets the card.
        /// </summary>
        public virtual Card Card { get; set; }

        /// <summary>
        /// Gets or sets the card's id.
        /// </summary>
        public int CardId { get; set; }

        /// <summary>
        /// Gets or sets the id of the inventory listing.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the user's id.
        /// </summary>
        public int UserId { get; set; }
    }
}