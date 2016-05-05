using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OrderEntrySystem.Utilities;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent a workspace view model.
    /// </summary>
    public abstract class WorkspaceViewModel : ViewModel
    {
        /// <summary>
        /// The delegate for the workspace view close command.
        /// </summary>
        private DelegateCommand closeCommand;

        /// <summary>
        /// The observable collection of command view models that provides notifications in the event of changes.
        /// </summary>
        private ObservableCollection<CommandViewModel> commands = new ObservableCollection<CommandViewModel>();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="description">The description of the workspace view model.</param>
        public WorkspaceViewModel(string description)
            : base(description)
        {
            this.Commands.Clear();
            this.CreateCommands();
            this.CloseButtonVisibility = "Visible";
        }

        /// <summary>
        /// The event handler for when a request to close the workspace occurs.
        /// </summary>
        public event EventHandler RequestClose;

        /// <summary>
        /// Gets or sets this is the workspace close action.
        /// </summary>
        public Action<bool> CloseAction { get; set; }

        /// <summary>
        /// Gets or sets whether the workspace has a close button.
        /// </summary>
        public string CloseButtonVisibility { get; set; }

        /// <summary>
        /// Gets a delegate for the workspace view close command.
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                if (this.closeCommand == null)
                {
                    this.closeCommand = new DelegateCommand(p => this.OnRequestClose());
                }
                return this.closeCommand;
            }
        }

        /// <summary>
        /// Gets the collection of command view models.
        /// </summary>
        public ObservableCollection<CommandViewModel> Commands
        {
            get
            {
                return this.commands;
            }
        }

        /// <summary>
        /// Creates new commands.
        /// </summary>
        protected abstract void CreateCommands();

        /// <summary>
        /// Sets the event handler when a request to close occurs..
        /// </summary>
        private void OnRequestClose()
        {
            // If close event handler is assigned...
            if (this.RequestClose != null)
            {
                // Call the event handler, passing in myself.
                this.RequestClose(this, EventArgs.Empty);
            }
        }
    }
}