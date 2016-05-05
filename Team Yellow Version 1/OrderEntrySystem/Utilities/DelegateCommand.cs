using System;
using System.Windows.Input;

namespace OrderEntrySystem.Utilities
{
    /// <summary>
    /// The class which is used to represent a delegate command.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// Whether or not the command can execute in its current state.
        /// </summary>
        private Predicate<object> canExecute;

        /// <summary>
        /// The delegate command.
        /// </summary>
        private Action<object> command;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="command">The delegate command.</param>
        public DelegateCommand(Action<object> command)
            : this(command, null)
        {
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="command">The delegate command.</param>
        /// <param name="canExecute">Whether or not the command can execute in its current state.</param>
        public DelegateCommand(Action<object> command, Predicate<object> canExecute)
        {
            if (command == null)
            {
                throw new Exception("Command was null");
            }

            this.command = command;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// The event handler for when the command's ability to execute has been modified.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Checks whether or not the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">The object parameter of the command.</param>
        /// <returns>Whether or not the command can execute in its current state.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute(parameter);
        }

        /// <summary>
        /// Executes the delegate command.
        /// </summary>
        /// <param name="parameter">The object parameter of the command.</param>
        public void Execute(object parameter)
        {
            this.command(parameter);
        }
    }
}