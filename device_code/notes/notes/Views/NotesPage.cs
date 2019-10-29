using Xamarin.Forms;

namespace notes
{
    public class NotesPage : ContentPage
    {
        // View Constructor
        public NotesPage()
        {
            // Init
            Title = "Notes";
            BindingContext = new NotesPageViewModel(Navigation);


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
                    new BoxView
                    {
                        BackgroundColor = Color.DarkGray,
                        HeightRequest = 1,
                        WidthRequest = 1
                    },
                    new StackLayout
                    {
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
            
            var collectionView = new CollectionView
            {
                ItemTemplate = new NotesTemplate(),
                SelectionMode = SelectionMode.Single
            };
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, nameof(NotesPageViewModel.NotesCollection));
            collectionView.SetBinding(CollectionView.SelectedItemProperty, nameof(NotesPageViewModel.SelectedNote));
            collectionView.SetBinding(CollectionView.SelectionChangedCommandProperty, nameof(NotesPageViewModel.NoteSelectedCommand));

            
            // Load up page content
            Content = new StackLayout
            {
                Children =
                {
                    addButton,
                    showDoneNotesBundle
                }
            };
        }


        // Data template class for notes
        class NotesTemplate : DataTemplate
        {
            public NotesTemplate() : base(LoadTemplate)
            {
            }

            static StackLayout LoadTemplate()
            {
                var textLabel = new Label();
                textLabel.SetBinding(Label.TextProperty, nameof(NoteModel.Title));

                var frame = new Frame
                {
                    VerticalOptions = LayoutOptions.Center,
                    Content = textLabel
                };

                return new StackLayout
                {
                    Children = { frame },
                    Padding = new Thickness(10, 10)
                };
            }
        }
    }
}
