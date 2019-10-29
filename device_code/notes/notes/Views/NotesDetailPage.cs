using System;
using Xamarin.Forms;

namespace notes
{
    public class NotesDetailPage : ContentPage
    {
        // View constructor
        public NotesDetailPage(NotesPageViewModel notesPageViewModel)
        {
            // Init
            Title = "Note Details";
            BindingContext = new NotesDetailPageViewModel(notesPageViewModel);


            // Note Title Entry
            var noteTitleEntry = new Entry
            {
                Placeholder = "Note Title*",
                FontSize = 20,
                BackgroundColor = Color.LightGray,
                Margin = new Thickness(10, 10, 10, 0)
            };
            noteTitleEntry.SetBinding(Entry.TextProperty, nameof(NotesDetailPageViewModel.NoteTitle));


            // Note Text Editor
            var noteTextEditor = new Editor
            {
                Placeholder = "Enter Note",
                FontSize = 20,
                BackgroundColor = Color.LightGray,
                Margin = new Thickness(10, 10, 10, 0),
                HeightRequest = 120
            };
            noteTextEditor.SetBinding(Editor.TextProperty, nameof(NotesDetailPageViewModel.NoteText));


            // Has Due Date Switch
            var hasDueDateSwitch = new Switch
            {
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Start
            };
            hasDueDateSwitch.SetBinding(Switch.IsToggledProperty, nameof(NotesDetailPageViewModel.HasDueDate));

            var hasDueDateBundle = new StackLayout
            {
                Margin = new Thickness(10, 10, 10, 0),
                BackgroundColor = Color.LightGray,
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Label
                    {
                        Text = "Has Due Date?",
                        FontSize = 20,
                        Padding = new Thickness(3, 8),
                    },
                    hasDueDateSwitch
                }
            };


            // Due Date Picker
            var dueDatePicker = new DatePicker
            {
                FontSize = 20,
                MinimumDate = new DateTime(2019, 1, 1),
                MaximumDate = new DateTime(2022, 12, 31)
            };
            dueDatePicker.SetBinding(DatePicker.DateProperty, nameof(NotesDetailPageViewModel.DueDate));

            var dueDateBundle = new StackLayout
            {
                Margin = new Thickness(10, 10, 10, 0),
                BackgroundColor = Color.LightGray,
                Children =
                {
                    new Label
                    {
                        Text = "Due Date",
                        FontSize = 20,
                        Padding = new Thickness(3, 0)
                    },
                    dueDatePicker
                }
            };
            dueDateBundle.SetBinding(StackLayout.IsVisibleProperty, nameof(NotesDetailPageViewModel.HasDueDate));


            // Done Switch
            var doneSwitch = new Switch
            {
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Start
            };
            doneSwitch.SetBinding(Switch.IsToggledProperty, nameof(NotesDetailPageViewModel.Done));

            var doneBundle = new StackLayout
            {
                Margin = new Thickness(10, 10, 10, 0),
                BackgroundColor = Color.LightGray,
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Label
                    {
                        Text = "Done",
                        FontSize = 20,
                        Padding = new Thickness(3, 8),
                    },
                    doneSwitch
                }
            };


            // Action Buttons
            var saveButton = new Button
            {
                Text = "Save",
                FontSize = 20,
                ImageSource = ImageSource.FromResource("notes.Assets.disk.png"),
                TextColor = Color.White,
                WidthRequest = 160,
                BackgroundColor = (Color)App.Current.Resources["dctBlue"]
            };
            saveButton.SetBinding(Button.CommandProperty, nameof(NotesDetailPageViewModel.SaveNoteCommand));

            var deleteButton = new Button
            {
                Text = "Delete",
                FontSize = 20,
                Margin = new Thickness(10, 0),
                ImageSource = ImageSource.FromResource("notes.Assets.trash.png"),
                TextColor = Color.White,
                WidthRequest = 160,
                BackgroundColor = (Color)App.Current.Resources["dctBlue"]
            };
            deleteButton.SetBinding(Button.CommandProperty, nameof(NotesDetailPageViewModel.DeleteNoteCommand));

            var actionButtonsBundle = new StackLayout
            {
                Margin = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    saveButton,
                    deleteButton
                }
            };


            // Footnote
            var footnote = new Label
            {
                Text = "* Required",
                FontSize = 15,
                TextColor = Color.Gray,
                Margin = new Thickness(10, 0)
            };


            // Load up page content
            Content = new StackLayout
            {
                Children =
                {
                    noteTitleEntry,
                    noteTextEditor,
                    hasDueDateBundle,
                    dueDateBundle,
                    doneBundle,
                    actionButtonsBundle,
                    footnote
                }
            };
        }
    }
}
