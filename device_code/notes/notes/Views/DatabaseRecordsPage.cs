using Xamarin.Forms;

namespace notes
{
    public class DatabaseRecordsPage : CarouselPage
    {
        public DatabaseRecordsPage(DatabasePageViewModel databasePageViewModel)
        {
            Title = $"{databasePageViewModel.SelectedTable.TableName} Records";
            var databaseRecordsPagelViewModel = new DatabaseRecordsPagelViewModel(databasePageViewModel);
            BindingContext = databaseRecordsPagelViewModel;
            

            // Records Carousel View
            ItemTemplate = new DataTemplate(() =>
            {
                // Pull data
                var localId = FormatFieldData("LocalId");
                var serverId = FormatFieldData("ServerId", true);
                var noteTitle = FormatFieldData("NoteTitle");
                var noteText = FormatFieldData("NoteText");
                var hasDueDate = FormatFieldData("HasDueDate");
                var dueDate = FormatFieldData("DueDate");
                var done = FormatFieldData("Done");
                var isDeleted = FormatFieldData("IsDeleted");
                var lastUpdated = FormatFieldData("LastUpdated");
                var lastSync = FormatFieldData("LastSync");


                // Return the content
                return new ContentPage
                {
                    Padding = new Thickness(10),
                    Content = new StackLayout
                    {
                        Children = {
                            localId,
                            serverId,
                            noteTitle,
                            noteText,
                            hasDueDate,
                            dueDate,
                            done,
                            isDeleted,
                            lastUpdated,
                            lastSync
                        }
                    }
                };
            });


            // Binding for Carousel View
            ItemsSource = databaseRecordsPagelViewModel.NotesListAll;
        }


        // Format data for each field of each record
        private StackLayout FormatFieldData(string fieldName, bool smallValueText = false)
        {
            var field = new Label
            {
                FontSize = smallValueText ? 15 : 20,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Start
            };
            field.SetBinding(Label.TextProperty, fieldName);

            return new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                    {
                        new Label
                        {
                            Text = $"{fieldName}:  ",
                            FontSize = 20,
                            FontAttributes = FontAttributes.Bold,
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalOptions = LayoutOptions.Start
                        },
                        field
                    }
            };
        }
    }
}
