using Xamarin.Forms;

namespace notes
{
    public class DatabasePage : ContentPage
    {

        // Database page constructor
        public DatabasePage()
        {
            //Init
            Title = "Database Page";
            BindingContext = new DatabasePageViewModel(Navigation);


            // Table Mapping Button
            var tableMappingButton = new Button
            {
                Text = "Table Mapping",
                FontSize = 20,
                ImageSource = ImageSource.FromResource("notes.Assets.table.png"),
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 240,
                Margin = new Thickness(10, 10, 10, 0),
                BackgroundColor = (Color)App.Current.Resources["dctBlue"]
            };
            tableMappingButton.SetBinding(Button.CommandProperty, nameof(DatabasePageViewModel.TableMappingCommand));

            Content = new StackLayout
            {
                Children = 
                {
                    tableMappingButton
                }
            };
        }
    }
}
