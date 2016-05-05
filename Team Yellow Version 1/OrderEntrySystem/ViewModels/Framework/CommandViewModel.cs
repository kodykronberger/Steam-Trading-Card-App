using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent the command view model.
    /// </summary>
    public class CommandViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="displayName">The command's display name.</param>
        /// <param name="command">The command.</param>
        public CommandViewModel(string displayName, ICommand command)
            : base(displayName)
        {
            if (command == null)
            {
                throw new Exception("Command was null");
            }

            this.Command = command;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        public ICommand Command { get; private set; }
    }
}