using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent the post as an event argument.
    /// </summary>
    public class PostEventArgs
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="post">The post for which the event occurs.</param>
        public PostEventArgs(Post post)
        {
            this.Post = post;
        }

        /// <summary>
        /// Gets the post object of the event.
        /// </summary>
        public Post Post { get; private set; }
    }
}