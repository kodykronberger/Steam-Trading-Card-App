using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent the current page changed event argument.
    /// </summary>
    public class CurrentPageChangedEventArgs
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="startIndex">The starting index of the page for which the event occurs.</param>
        /// <param name="itemCount">The total item count for which the event occurs.</param>
        public CurrentPageChangedEventArgs(int startIndex, int itemCount)
        {
            this.StartIndex = startIndex;
            this.ItemCount = itemCount;
        }

        /// <summary>
        /// Gets the total item count.
        /// </summary>
        public int ItemCount { get; private set; }

        /// <summary>
        /// Gets the starting index of the page.
        /// </summary>
        public int StartIndex { get; private set; }
    }
}