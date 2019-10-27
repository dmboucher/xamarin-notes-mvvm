using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace notes
{
    public static class ExtensionMethods
    {
        public static async Task PushOnceAsync<T>(this INavigation navigation, bool animated = false)
        {
            var getPage = navigation.NavigationStack.FirstOrDefault(p => p is T) ?? (Page)Activator.CreateInstance(typeof(T));
            await navigation.PushAsync(getPage, animated);
        }
    }
}
