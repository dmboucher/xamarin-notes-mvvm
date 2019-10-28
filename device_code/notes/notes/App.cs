using System;
using System.IO;
using Xamarin.Forms;

namespace notes
{
    public class App : Application
    {
        static NoteDatabase database;

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

        public static NoteDatabase Database
        {
            // Get or create database
            get
            {
                if (database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLiteNote.db3"));
                }
                return database;
            }
        }

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
