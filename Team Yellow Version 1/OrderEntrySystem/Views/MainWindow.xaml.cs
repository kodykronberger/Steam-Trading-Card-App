using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrderEntrySystem.Utilities;
using OrderEntrySystem.Windows;

namespace OrderEntrySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Closes all notifications on main window close.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments of the event.</param>
        private void Window_Closed(object sender, EventArgs e)
        {
            foreach (NotificationWindow notification in Notifications.AllNotifications)
            {
                notification.Close();
            }
        }
    }
}