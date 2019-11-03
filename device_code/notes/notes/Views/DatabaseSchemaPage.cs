using Xamarin.Forms;

namespace notes
{
    public class DatabaseSchemaPage : ContentPage
    {
        public DatabaseSchemaPage(DatabasePageViewModel databasePageViewModel)
        {
            Title = "Database Schema";
            BindingContext = new DatabaseSchemaPagelViewModel(databasePageViewModel);


            // Title
            var tableName = new Label
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };
            tableName.SetBinding(Label.TextProperty, "TableDisplayName");

            var titleBundle = new StackLayout
            {
                Margin = new Thickness(10, 10, 10, 0),
                Children =
                {
                    tableName,
                    new BoxView
                    {
                        Margin = new Thickness(0, 5, 0, 0),
                        BackgroundColor = Color.DarkGray,
                        HeightRequest = 1,
                        WidthRequest = 1
                    }
                }
            };

            
            // Schema List View
            var schemaListView = new ListView
            {
                Margin = new Thickness(20, 5),
                ItemTemplate = new DataTemplate(() =>
                {
                    var fieldName = new Label
                    {
                        FontSize = 20,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.Start
                    };
                    fieldName.SetBinding(Label.TextProperty, "Name");

                    var notNull = new Label
                    {
                        FontSize = 20,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.EndAndExpand
                    };
                    notNull.SetBinding(Label.TextProperty, new Binding("notnull", converter: new ValueConverter()));

                    var stackLayout = new StackLayout
                    {
                        Padding = new Thickness(5),
                        Margin = new Thickness(0, 0, 0, 2),
                        BackgroundColor = Color.LightGray,
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children =
                        {
                            fieldName,
                            notNull
                        }
                    };

                    return new ViewCell { View = stackLayout };
                })
            };
            schemaListView.SetBinding(ListView.ItemsSourceProperty, nameof(DatabaseSchemaPagelViewModel.TableInfo));


            // Load up content
            Content = new StackLayout
            {
                Children = {
                    titleBundle,
                    schemaListView
                }
            };
        }
    }
}
