using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent the news as an event argument.
    /// </summary>
    public class NewsEventArgs
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="news">The news for which the event occurs.</param>
        public NewsEventArgs(News news)
        {
            this.News = news;
        }

        /// <summary>
        /// Gets or sets the news object of the event.
        /// </summary>
        public News News { get; set; }
    }
}