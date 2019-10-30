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

            ToolbarItem syncToolbarItem = new ToolbarItem
            {
                Order = ToolbarItemOrder.Primary,
                Priority = 3,
                IconImageSource = ImageSource.FromResource("notes.Assets.sync.png")
            };

            ToolbarItems.Add(notesToolbarItem);
            ToolbarItems.Add(databaseToolbarItem);
            ToolbarItems.Add(syncToolbarItem);

            notesToolbarItem.Clicked += OnNotesItemClicked;
            databaseToolbarItem.Clicked += OnDatabaseItemClicked;
            syncToolbarItem.Clicked += OnSyncItemClicked;
        }


        // Click handlers
        async void OnNotesItemClicked(object sender, EventArgs e)
        {
            // ToolbarItem item = (ToolbarItem)sender; // This is the syntax in case we need to interrogate the clicked item
            await Navigation.PushAsync(new NotesPage()).ConfigureAwait(false);
        }

        async void OnDatabaseItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatabasePage()).ConfigureAwait(false);
        }

        async void OnSyncItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SyncPage()).ConfigureAwait(false);
        }
    }
}
