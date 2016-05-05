using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent a Steam user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the ID number of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the inventories that own the object.
        /// </summary>
        public virtual ICollection<Inventory> Inventorys { get; set; }

        /// <summary>
        /// Gets or sets the specific Steam ID number of the user.
        /// </summary>
        public string SteamId { get; set; }

        /// <summary>
        /// Gets or sets the Steam display name of the user.
        /// </summary>
        public string Username { get; set; }
    }
}