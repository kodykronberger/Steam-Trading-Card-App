using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Newtonsoft.Json.Linq;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    /// <summary>
    /// Interaction logic for ProfileSignInView.xaml
    /// </summary>
    public partial class ProfileSignInView : UserControl
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ProfileSignInView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Join the steam powered store.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void LabelMouseDownCreateAccount(object sender, MouseButtonEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://store.steampowered.com/join/?");
            }
            catch
            {
            }
        }

        /// <summary>
        /// Create an account.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void LabelMouseEnterCreateAccount(object sender, MouseEventArgs e)
        {
            // Note: the call to cursor must begin with: this, base, object, ProfileSignInView, or UserControl to indicate method call.
            this.Cursor = Cursors.Hand;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://steamid.xyz/");
            }
            catch
            {
            }
        }
    }
}