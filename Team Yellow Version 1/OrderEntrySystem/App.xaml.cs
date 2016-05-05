using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// This is the on startup
        /// </summary>
        /// <param name="e">This runs on startup</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create main window.
            MainWindow window = new MainWindow();

            var viewModel = new MainWindowViewModel();

            // Attach main window to an underlying view model.
            window.DataContext = viewModel;

            // Show main window
            window.Show();
        }
    }
}