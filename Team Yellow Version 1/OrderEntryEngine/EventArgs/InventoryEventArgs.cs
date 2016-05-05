using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent the inventory as an event argument.
    /// </summary>
    public class InventoryEventArgs
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="inventory">The inventory for which the event occurs.</param>
        public InventoryEventArgs(Inventory inventory)
        {
            this.Inventory = inventory;
        }

        /// <summary>
        /// Gets the Inventory object of the event.
        /// </summary>
        public Inventory Inventory { get; private set; }
    }
}