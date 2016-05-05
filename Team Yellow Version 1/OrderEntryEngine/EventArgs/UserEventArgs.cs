using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent the user as an event argument.
    /// </summary>
    public class UserEventArgs
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="user">The user for which the event occurs.</param>
        public UserEventArgs(User user)
        {
            this.User = user;
        }

        /// <summary>
        /// Gets the user object of the event.
        /// </summary>
        public User User { get; private set; }
    }
}