using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace notes
{
    public class NotesDetailPageViewModel : INotifyPropertyChanged
    {
        string noteTitle;
        public string NoteTitle
        {
            get => noteTitle;
            set
            {
                noteTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteTitle)));
            }
        }

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
            }
        }

        public NotesDetailPageViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
