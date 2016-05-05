using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent a search posts view model.
    /// </summary>
    public class SearchPostsViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The database repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="repository">The database repository.</param>
        public SearchPostsViewModel(Repository repository)
            : base("Search Posts")
        {
            this.repository = repository;
        }

        /// <summary>
        /// Creates the commands.
        /// </summary>
        protected override void CreateCommands()
        {
        }
    }
}