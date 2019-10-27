using Xamarin.Forms;

namespace notes
{
    public class SyncPage : ContentPage
    {
        // Control properties
        readonly Label txtSplash;

        // Database page constructor
        public SyncPage()
        {
            Title = "Sync";

            // Define controls & their bindings
            txtSplash = new Label
            {
                FontSize = 20,
                Margin = new Thickness(10),
                Text = "Sync Page"
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
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star) }
                }
            };


            // Add Controls to grid
            grid.Children.Add(txtSplash, 0, 0);
            Grid.SetColumnSpan(txtSplash, 2);


            // Set the page content
            Content = grid;
        }
    }
}
