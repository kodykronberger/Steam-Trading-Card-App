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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OrderEntrySystem.Windows
{
    /// <summary>
    /// Interaction logic for NotificationWindow.xaml
    /// </summary>
    public partial class NotificationWindow : Window
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NotificationWindow()
        {
            this.InitializeComponent();

            Dispatcher.BeginInvoke(
                DispatcherPriority.ApplicationIdle,
                new Action(() =>
                    {
                        // Gets the work area of the system. (Resolution of screen)
                        var workingArea = System.Windows.SystemParameters.WorkArea;

                        // Gets the number of notification windows currently open.
                        int numberOfNotifications = Application.Current.Windows.OfType<NotificationWindow>().Count() - 1;

                        // Transformer
                        var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;

                        // Sets the corner of notification. (All the way to the right of the screen, and 100 units up for each notification to stack.)
                        var corner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom - (numberOfNotifications * 108)));

                        // Sets position of alert.
                        this.Left = corner.X - this.ActualWidth;
                        this.Top = corner.Y - this.ActualHeight;
                    }));
        }

        /// <summary>
        /// Closes the notification window on close click.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments of the event.</param>
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Closes the notification window after duration.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments of the event.</param>
        private void closeAnim_Completed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}