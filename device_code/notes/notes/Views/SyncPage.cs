using Xamarin.Forms;

namespace notes
{
    public class SyncPage : ContentPage
    {
        public SyncPage()
        {
            Title = "Sync Page";

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Sync Page" }
                }
            };
        }
    }
}
