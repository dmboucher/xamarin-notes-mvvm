using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace notes
{
    public class NotesDetailPage : ContentPage
    {
        public NotesDetailPage(NotesDetailPageViewModel viewModel)
        {
            Title = "Note Details";
            BindingContext = viewModel;

            Content = new StackLayout
            {
                Children = 
                {
                    new Entry
                    {
                        Placeholder = "Note Title",
                        BackgroundColor = Color.LightGray,
                        Margin = new Thickness(10),
                        BindingContext = (Editor.TextProperty, nameof(NotesDetailPageViewModel.NoteTitle))
                    },

                    new Editor
                    {
                        Placeholder = "Enter Note",
                        BackgroundColor = Color.LightGray,
                        Margin = new Thickness(10),
                        BindingContext = (Editor.TextProperty, nameof(NotesDetailPageViewModel.NoteText))
                    }
                }
            };
        }
    }
}
