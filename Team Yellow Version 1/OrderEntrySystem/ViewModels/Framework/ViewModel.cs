using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent a view model.
    /// </summary>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        public ViewModel(string displayName)
        {
            this.DisplayName = displayName;
        }

        /// <summary>
        /// The event handler for when a property has been changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Sets the display string for the view model.
        /// </summary>
        /// <returns>The display string.</returns>
        public override string ToString()
        {
            return this.DisplayName;
        }

        /// <summary>
        /// Sets the event handler on property change.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            // If there is a listener...
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}