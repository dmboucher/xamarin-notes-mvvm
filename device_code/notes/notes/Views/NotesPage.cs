using Xamarin.Forms;

namespace notes
{
    public class NotesPage : ContentPage
    {
        // Control properties
        readonly Label txtTitle;


        // Main page constructor
        public NotesPage()
        {
            Title = "Notes";
            BindingContext = new NotesPageViewModel();


            // Define controls & their bindings
            txtTitle = new Label
            {
                FontSize = 20,
                Margin = new Thickness(10),
                Text = "Notes Page"
            };


            // Define grid
            var grid = new Grid
            {
                Margin = new Thickness(20, 40),

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },

                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star) }
                }
            };


            // Add Controls to grid
            grid.Children.Add(txtTitle, 0, 0);
            Grid.SetColumnSpan(txtTitle, 2);

            // Set the page content
            Content = grid;
        }
    }
}
