using Xamarin.Forms;

namespace notes
{
    public class HomePage : Menu
    {
        // Control properties
        readonly Image imgDct;
        readonly Label txtSplash;


        // Main page constructor
        public HomePage()
        {
            Title = "Dave's DCT Demo";


            // Define controls & their bindings
            imgDct = new Image
            {
                Source = ImageSource.FromResource("notes.Assets.dct.png")
            };

            txtSplash = new Label
            {
                FontSize = 20,
                Margin = new Thickness(10),
                Text = "Dave's little app playground.\nJust messing around with Xamarin, MVVM, SQLite, and Azure!"
            };


            // Define grid - we don't really need a grid here... I'm just playing with the grid to learn it
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
                    new RowDefinition { Height = new GridLength(1.5, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star) }
                }
            };


            // Add Controls to grid
            grid.Children.Add(imgDct, 0, 0);
            Grid.SetColumnSpan(imgDct, 2);

            grid.Children.Add(txtSplash, 0, 1);
            Grid.SetColumnSpan(txtSplash, 2);


            // Set the page content
            Content = grid;
        }
    }
}
