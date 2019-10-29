using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace notes
{
    public class NotesPage : ContentPage
    {
        // TODO: Refactor the ListView to be an ObservableCollection.
        //       This should allow the removal of the custom ItemTapped handler.
        //       With an ObservableCollection, we could take advantage of that control's built-in item tap handlers.


        // View Constructor
        public NotesPage()
        {
            // Init
            Title = "Notes";
            var notesPageViewModel = new NotesPageViewModel(Navigation);
            BindingContext = notesPageViewModel;


            // Add Note Button
            var addButton = new Button
            {
                Text = "Add Note",
                FontSize = 20,
                ImageSource = ImageSource.FromResource("notes.Assets.plus.png"),
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 160,
                Margin = new Thickness(10, 10, 10, 0),
                BackgroundColor = (Color)App.Current.Resources["dctBlue"]
            };
            addButton.SetBinding(Button.CommandProperty, nameof(NotesPageViewModel.AddNoteCommand));


            // Show Done Notes Switch
            var showDoneNotes = new Switch
            {
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Start
            };
            showDoneNotes.SetBinding(Switch.IsToggledProperty, nameof(NotesPageViewModel.ShowDoneNotes));

            var showDoneNotesBundle = new StackLayout
            {
                Margin = new Thickness(10, 10, 10, 0),
                Children =
                {
                    new StackLayout
                    {
                        Padding = new Thickness(5),
                        BackgroundColor = Color.LightGray,
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new Label
                            {
                                Text = "Show Done Notes",
                                FontSize = 20
                            },
                            showDoneNotes
                        }
                    }
                }
            };


            // Title
            var titleBundle = new StackLayout
            {
                Margin = new Thickness(10, 5, 10, 0),
                Children =
                {
                    new BoxView
                    {
                        Margin = new Thickness(0, 5, 0, 0),
                        BackgroundColor = Color.DarkGray,
                        HeightRequest = 1,
                        WidthRequest = 1
                    },
                    new Label
                    {
                        Text = "Notes:",
                        FontSize = 20,
                        FontAttributes = FontAttributes.Bold
                    }
                }
            };


            var notesListView = new ListView
            {
                Margin = new Thickness(20, 5),
                ItemTemplate = new DataTemplate(() =>
                {
                    var label = new Label
                    {
                        FontSize = 20,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.Start
                    };
                    label.SetBinding(Label.TextProperty, "NoteTitle");

                    var tick = new Image
                    {
                        Source = ImageSource.FromResource("notes.Assets.check.png"),
                        HorizontalOptions = LayoutOptions.EndAndExpand
                    };
                    tick.SetBinding(VisualElement.IsVisibleProperty, "Done");

                    var stackLayout = new StackLayout
                    {
                        Padding = new Thickness(5),
                        Margin = new Thickness(0, 0, 0, 2),
                        BackgroundColor = Color.LightGray,
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = 
                        { 
                            label, 
                            tick 
                        }
                    };

                    return new ViewCell { View = stackLayout };
                })
            };
            notesListView.SetBinding(ListView.ItemsSourceProperty, nameof(NotesPageViewModel.NotesListViewable));
            notesListView.SetBinding(ListView.SelectedItemProperty, nameof(NotesPageViewModel.SelectedNote));
            notesListView.ItemTapped += async (sender, e) => { notesPageViewModel.NoteSelectedCommand.Execute(null); };


            // Load up page content
            Content = new StackLayout
            {
                Children =
                {
                    addButton,
                    showDoneNotesBundle,
                    titleBundle,
                    notesListView
                }
            };
        }
    }
}
