using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent the database initializer.
    /// </summary>
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<OrderEntryContext>
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context">The order entry context.</param>
        protected override void Seed(OrderEntryContext context)
        {
            context.News.Add(new News { Content = "Working on news", DatePosted = DateTime.Parse("12/2/2015") });
            context.News.Add(new News { Content = "Start up", DatePosted = DateTime.Now });
            context.SaveChanges();
        }
    }
}