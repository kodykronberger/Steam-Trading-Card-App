using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderEntryEngine;
using OrderRepository;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent a browse all games view model.
    /// </summary>
    public class BrowseAllGamesViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The database repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="repository">The database repository.</param>
        public BrowseAllGamesViewModel(Repository repository)
            : base("Browse All Games")
        {
            ////// Clear the commands
            this.Commands.Clear();
            this.CreateCommands();
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