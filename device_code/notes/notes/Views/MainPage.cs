using Xamarin.Forms;

namespace notes
{
    public class MainPage : ContentPage
    {
        // Control properties
        readonly Image imgDct;
        readonly Label txtSplash;
        readonly Button btnContinue;


        // Main page constructor
        public MainPage()
        {
            // Define Controls
            imgDct = new Image
            {
                Source = ImageSource.FromResource("notes.Assets.dct.png")  //, typeof(EmbeddedImages).GetTypeInfo().Assembly
            };

            txtSplash = new Label
            {
                FontSize = 20,
                Margin = new Thickness(10),
                Text = "Dave's little app playground. Just messing around with Xamarin, MVVM, SQLite, and Azure!"
            };

            btnContinue = new Button
            {
                Text = "Continue",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("0069AA"),
                Margin = new Thickness(10)
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
                    new RowDefinition { Height = new GridLength(1.5, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) }
                }
            };


            // Add Controls to grid
            grid.Children.Add(imgDct, 0, 0);
            Grid.SetColumnSpan(imgDct, 2);

            grid.Children.Add(txtSplash, 0, 1);
            Grid.SetColumnSpan(txtSplash, 2);

            grid.Children.Add(btnContinue, 0, 2);


            // Set the page content
            Content = grid;
        }
    }
}
