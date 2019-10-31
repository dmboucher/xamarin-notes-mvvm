using Xamarin.Forms;

namespace notes
{
    public class DatabasePage : ContentPage
    {

        // Database page constructor
        public DatabasePage()
        {
            //Init
            Title = "Database Utilities";
            var databasePageViewModel = new DatabasePageViewModel(Navigation);
            BindingContext = databasePageViewModel;


            // Title
            var titleBundle = new StackLayout
            {
                Margin = new Thickness(10, 10, 10, 0),
                Children =
                {
                    new Label
                    {
                        Text = "Tables In Database:",
                        FontSize = 20,
                        FontAttributes = FontAttributes.Bold
                    },
                    new BoxView
                    {
                        Margin = new Thickness(0, 5, 0, 0),
                        BackgroundColor = Color.DarkGray,
                        HeightRequest = 1,
                        WidthRequest = 1
                    }
                }
            };


            // Table list
            var tableListView = new ListView
            {
                Margin = new Thickness(20, 5),
                ItemTemplate = new DataTemplate(() =>
                {
                    // Table Name
                    var tableName = new Label
                    {
                        FontSize = 20,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.Start
                    };
                    tableName.SetBinding(Label.TextProperty, "TableName");

                    // Schema Button
                    var schema = new Image
                    {
                        Source = ImageSource.FromResource("notes.Assets.schema.png"),
                        HorizontalOptions = LayoutOptions.EndAndExpand
                    };
                    var schemaRecognizer = new TapGestureRecognizer() { Command = databasePageViewModel.TableSchemaCommand };
                    schemaRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, ".");
                    schema.GestureRecognizers.Add(schemaRecognizer);

                    // Records Button
                    var records = new Image
                    {
                        Source = ImageSource.FromResource("notes.Assets.records.png"),
                        Margin = new Thickness(10, 0, 0, 0),
                        HorizontalOptions = LayoutOptions.End
                    };
                    var recordRecognizer = new TapGestureRecognizer() { Command = databasePageViewModel.TableRecordsCommand };
                    recordRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, ".");
                    records.GestureRecognizers.Add(recordRecognizer);

                    // Load up content for the ViewCell
                    var stackLayout = new StackLayout
                    {
                        Padding = new Thickness(5),
                        Margin = new Thickness(0, 0, 0, 2),
                        BackgroundColor = Color.LightGray,
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children =
                        {
                            tableName,
                            schema,
                            records
                        }
                    };

                    return new ViewCell { View = stackLayout };
                })
            };
            tableListView.SetBinding(ListView.ItemsSourceProperty, nameof(DatabasePageViewModel.TableListViewable));
            tableListView.SetBinding(ListView.SelectedItemProperty, nameof(DatabasePageViewModel.SelectedTable));


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


            // Load up the content
            Content = new StackLayout
            {
                Children = 
                {
                    titleBundle,
                    tableListView,
                    tableMappingButton
                }
            };
        }
    }
}
