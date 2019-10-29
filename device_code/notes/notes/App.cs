using System;
using System.IO;
using Xamarin.Forms;

namespace notes
{
    public class App : Application
    {
        // App properties
        static NoteDatabase database;


        // App constructor
        public App()
        {
            // Color resources to use throughout the app
            Resources = new ResourceDictionary
            {
                { "dctGreen", Color.FromHex("8CC63E") },
                { "dctBlue", Color.FromHex("0069AA") }
            };

            // Init the main page
            MainPage = new NavigationPage(new HomePage()) 
            { 
                BarBackgroundColor = (Color)App.Current.Resources["dctBlue"]
            };
        }


        // Get or create database
        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLiteNote.db3"));
                }
                return database;
            }
        }


        // State overrides
        protected override void OnStart()
        {
            // Stub
        }

        protected override void OnSleep()
        {
            // Stub
        }

        protected override void OnResume()
        {
            // Stub
        }
    }
}
