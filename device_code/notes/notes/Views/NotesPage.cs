using Xamarin.Forms;

namespace notes
{
    public class NotesPage : ContentPage
    {
        public NotesPage()
        {
            // Init
            Title = "Notes";
            BindingContext = new NotesPageViewModel(Navigation);


            // Define controls & their bindings
            var btnAdd = new Button
            {
                Text = "Add Note",
                FontSize = 20,
                ImageSource = ImageSource.FromResource("notes.Assets.plus.png"),
                TextColor = Color.White,
                BackgroundColor = (Color)App.Current.Resources["dctBlue"]
            };
            btnAdd.SetBinding(Button.CommandProperty, "AddNoteCommand");

            var swtDoneBundle = new StackLayout
            {
                Margin = new Thickness(0, 20, 0, 0),
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
                            new Switch
                            {
                                IsToggled = false,
                                HorizontalOptions = LayoutOptions.Start
                            }
                        }
                    }
                }
            };


            // Define grid
            var grid = new Grid
            {
                Margin = new Thickness(20),

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },

                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(0.25, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(0.2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(3.0, GridUnitType.Star) }
                }
            };


            // Add Controls to grid
            grid.Children.Add(btnAdd, 0, 0);
            
            grid.Children.Add(swtDoneBundle, 0, 1);
            Grid.SetColumnSpan(swtDoneBundle, 2);


            // Set the page content
            Content = grid;
        }
    }
}
