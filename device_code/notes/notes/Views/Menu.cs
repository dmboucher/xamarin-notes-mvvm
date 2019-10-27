using System;
using Xamarin.Forms;

namespace notes
{
    public class Menu : ContentPage
    {
        // Toolbar constructor
        public Menu()
        {
            Padding = 10;

            ToolbarItem notesToolbarItem = new ToolbarItem
            {
                Order = ToolbarItemOrder.Primary,
                Priority = 1,
                IconImageSource = ImageSource.FromResource("notes.Assets.edit.png")
            };

            ToolbarItem databaseToolbarItem = new ToolbarItem
            {
                Order = ToolbarItemOrder.Primary,
                Priority = 2,
                IconImageSource = ImageSource.FromResource("notes.Assets.database.png")
            };

            ToolbarItems.Add(notesToolbarItem);
            ToolbarItems.Add(databaseToolbarItem);

            notesToolbarItem.Clicked += OnNotesItemClicked;
            databaseToolbarItem.Clicked += OnDatabaseItemClicked;
        }

        async void OnNotesItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;
            await Navigation.PushAsync(new NotesPage()).ConfigureAwait(false);
        }

        async void OnDatabaseItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;
            await Navigation.PushAsync(new DatabasePage()).ConfigureAwait(false);
        }
    }
}
