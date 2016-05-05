using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent a news item.
    /// </summary>
    public class News
    {
        /// <summary>
        /// Gets or sets the news ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the news.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the news date.
        /// </summary>
        public DateTime DatePosted { get; set; }

        /// <summary>
        /// Sets the display string for the news.
        /// </summary>
        /// <returns>The display string.</returns>
        public override string ToString()
        {
            return this.DatePosted.ToString() + "\n" + this.Content + "\n\n";
        }
    }
}