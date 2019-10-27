using Xamarin.Forms;

namespace notes
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
            // Stub
        }

        protected override void OnSleep()
        {
            // Stub
        }

        protected override void OnResume()
        {
            // Stub
        }
    }
}
