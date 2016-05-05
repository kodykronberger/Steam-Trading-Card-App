using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using OrderEntrySystem.Windows;

namespace OrderEntrySystem.Utilities
{
    /// <summary>
    /// The class which is used to represent notifications.
    /// </summary>
    public static class Notifications
    {
        /// <summary>
        /// The list of all notification windows.
        /// </summary>
        public static List<NotificationWindow> AllNotifications = new List<NotificationWindow>();

        /// <summary>
        /// The loading window.
        /// </summary>
        public static LoadingWindow LoadingWindow;

        /// <summary>
        /// Closes the loading window.
        /// </summary>
        public static void CloseLoadingWindow()
        {
            LoadingWindow.Close();
        }

        /// <summary>
        /// Sets the loading window text.
        /// </summary>
        /// <param name="text">The text to set to.</param>
        public static void SetLoadingWindowText(string text)
        {
            LoadingWindow.statusLabel.Text = text;
        }

        /// <summary>
        /// Shows the desktop alert.
        /// </summary>
        /// <param name="title">The title of the alert.</param>
        /// <param name="message">The message on the alert.</param>
        public static void ShowDesktopAlert(string title, string message)
        {
            NotificationWindow notificationWindow = new NotificationWindow();

            notificationWindow.NotificationTitle.Text = title;
            notificationWindow.NotificationMessage.Text = message;

            AllNotifications.Add(notificationWindow);
            notificationWindow.Show();
            notificationWindow.Focus();
        }

        /// <summary>
        /// Shows the desktop alert.
        /// </summary>
        /// <param name="title">The title of the alert.</param>
        /// <param name="message">The message on the alert.</param>
        /// <param name="imagesource">The notification image source.</param>
        public static void ShowDesktopAlert(string title, string message, ImageSource imagesource)
        {
            NotificationWindow notificationWindow = new NotificationWindow();

            notificationWindow.NotificationTitle.Text = title;
            notificationWindow.NotificationMessage.Text = message;
            notificationWindow.profilePicture.Source = imagesource;

            AllNotifications.Add(notificationWindow);
            notificationWindow.Show();
            notificationWindow.Focus();
        }

        /// <summary>
        /// Shows the loading window.
        /// </summary>
        public static void ShowLoadingWindow()
        {
            Application.Current.Dispatcher.BeginInvoke(
                new Action(() =>
                {
                    LoadingWindow = new LoadingWindow();
                    LoadingWindow.Show();
                    LoadingWindow.Focus();
                }),
                DispatcherPriority.Send);
        }

        /// <summary>
        /// Shows the loading window.
        /// </summary>
        /// <param name="text">The text for the window.</param>
        public static void ShowLoadingWindow(string text)
        {
            Application.Current.Dispatcher.BeginInvoke(
                new Action(() =>
                {
                    LoadingWindow = new LoadingWindow();
                    LoadingWindow.statusLabel.Text = text;
                    LoadingWindow.Show();
                    LoadingWindow.Focus();
                }),
                DispatcherPriority.Send);
        }
    }
}