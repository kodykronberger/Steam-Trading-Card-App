using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent the order entry context.
    /// </summary>
    public class OrderEntryContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OrderEntryContext()
            : base("name=OrderEntryContext")
        {
            this.Database.Initialize(true);
        }

        /// <summary>
        /// Gets or sets the database set of cards.
        /// </summary>
        public DbSet<Card> Cards { get; set; }

        /// <summary>
        /// Gets or sets the database set of news.
        /// </summary>
        public DbSet<News> News { get; set; }

        /// <summary>
        /// Gets or sets the database set of games.
        /// </summary>
        public DbSet<Game> Games { get; set; }

        /// <summary>
        /// Gets or sets the database set of inventories.
        /// </summary>
        public DbSet<Inventory> Inventorys { get; set; }

        /// <summary>
        /// Gets or sets the database set of posts.
        /// </summary>
        public DbSet<Post> Posts { get; set; }

        /// <summary>
        /// Gets or sets the database set of users.
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}