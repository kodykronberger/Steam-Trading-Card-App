using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent the Current User (signed-in).
    /// </summary>
    public static class CurrentUser
    {
        /// <summary>
        /// Gets or sets the user currently signed in.
        /// </summary>
        public static User UserSignedIn { get; set; }

        /// <summary>
        /// Gets the user image of the current user.
        /// </summary>
        /// <returns>The current user's image.</returns>
        public static string GetUserImage()
        {
            if (UserSignedIn == null)
            {
                return string.Empty;
            }

            // Retrieve data from API.
            string apiKey = "5C84830E22F44B4D38999EEB7BB3F2B3";
            string jsonUrl = @"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" + apiKey + "&steamids=" + UserSignedIn.SteamId;
            WebClient wc = new WebClient();
            string json;

            try
            {
                json = wc.DownloadString(new Uri(jsonUrl));
            }
            catch (Exception)
            {
                MessageBox.Show("The server is unavailable right now. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return "Unknown User";
            }

            // The JSON data.
            JObject jsonobj;

            // If there is no JSON to be parsed, throw an error.
            try
            {
                jsonobj = JObject.Parse(json);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid steam id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Unknown User";
            }

            try
            {
                return (string)jsonobj["response"]["players"][0]["avatarfull"];
            }
            catch (Exception)
            {
                MessageBox.Show("Could not retrieve info about steam id.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return "Unknown User";
            }
        }

        /// <summary>
        /// Gets the user image of the current user.
        /// </summary>
        /// <param name="id">The current user's ID.</param>
        /// <returns>The user's Steam picture.</returns>
        public static string GetUserImageFromId(string id)
        {
            // Retrieve data from API.
            string apiKey = "5C84830E22F44B4D38999EEB7BB3F2B3";
            string jsonUrl = @"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" + apiKey + "&steamids=" + id;
            WebClient wc = new WebClient();
            string json;

            try
            {
                json = wc.DownloadString(new Uri(jsonUrl));
            }
            catch (Exception)
            {
                MessageBox.Show("The server is unavailable right now. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return "Unknown User";
            }

            // The JSON data.
            JObject jsonobj;

            // If there is no JSON to be parsed, throw an error.
            try
            {
                jsonobj = JObject.Parse(json);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid steam id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Unknown User";
            }

            try
            {
                return (string)jsonobj["response"]["players"][0]["avatarfull"];
            }
            catch (Exception)
            {
                MessageBox.Show("Could not retrieve info about steam id.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return "Unknown User";
            }
        }

        /// <summary>
        /// Gets the user name of the current user.
        /// </summary>
        /// <returns>The current user's user name.</returns>
        public static string GetUsername()
        {
            if (UserSignedIn == null)
            {
                return "Not signed in.";
            }

            // Retrieve data from API.
            string apiKey = "5C84830E22F44B4D38999EEB7BB3F2B3";
            string jsonUrl = @"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" + apiKey + "&steamids=" + UserSignedIn.SteamId;
            WebClient wc = new WebClient();
            string json;

            try
            {
                json = wc.DownloadString(new Uri(jsonUrl));
            }
            catch (Exception)
            {
                MessageBox.Show("The server is unavailable right now. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return "Unknown User";
            }

            // The JSON data.
            JObject jsonobj;

            // If there is no JSON to be parsed, throw an error.
            try
            {
                jsonobj = JObject.Parse(json);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid steam id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Unknown User";
            }

            try
            {
                return (string)jsonobj["response"]["players"][0]["personaname"];
            }
            catch (Exception)
            {
                MessageBox.Show("Could not retrieve info about steam id.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return "Unknown User";
            }
        }

        /// <summary>
        /// Gets the user name of the current user.
        /// </summary>
        /// <param name="id">The current user's ID.</param>
        /// <returns>The current user's user name.</returns>
        public static string GetUsernameFromId(string id)
        {
            if (UserSignedIn == null)
            {
                return "Not signed in.";
            }

            // Retrieve data from API.
            string apiKey = "5C84830E22F44B4D38999EEB7BB3F2B3";
            string jsonUrl = @"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" + apiKey + "&steamids=" + id;
            WebClient wc = new WebClient();
            string json;

            try
            {
                json = wc.DownloadString(new Uri(jsonUrl));
            }
            catch (Exception)
            {
                MessageBox.Show("The server is unavailable right now. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return "Unknown User";
            }

            // The JSON data.
            JObject jsonobj;

            // If there is no JSON to be parsed, throw an error.
            try
            {
                jsonobj = JObject.Parse(json);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid steam id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Unknown User";
            }

            try
            {
                return (string)jsonobj["response"]["players"][0]["personaname"];
            }
            catch (Exception)
            {
                MessageBox.Show("Could not retrieve info about steam id.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return "Unknown User";
            }
        }
    }
}