using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent a post.
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Gets or sets the card to offer name string.
        /// </summary>
        public Card CardToHave { get; set; }

        /// <summary>
        /// Gets or sets the card to request name string.
        /// </summary>
        public Card CardToWant { get; set; }

        /// <summary>
        /// Gets or sets the date the post was made.
        /// </summary>
        public DateTime DatePosted { get; set; }

        /// <summary>
        /// Gets or sets a description for the post.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the list of games.
        /// </summary>
        public GameEnum ListOfGame { get; set; }

        /// <summary>
        /// Gets or sets the post's ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the post.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with the post.
        /// </summary>
        public int UserId { get; set; }
    }
}