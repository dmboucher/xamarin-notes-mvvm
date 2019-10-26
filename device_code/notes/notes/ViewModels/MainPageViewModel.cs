using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace notes
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            //NotesCollection = new ObservableCollection<NoteModel>();

            //SaveNoteCommand = new Command(() =>
            //{
            //    var note = new NoteModel
            //    {
            //        Text = NoteText
            //    };

            //    NotesCollection.Add(note);

            //    NoteText = string.Empty;
            //});

        }

        public event PropertyChangedEventHandler PropertyChanged;

        //string noteText;
        //public string NoteText
        //{
        //    get => noteText;
        //    set
        //    {
        //        noteText = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(typeof(NoteText)));
        //        SaveNoteCommand.ChangeCanExecute();
        //    }
        //}
            
        //public ObservableCollection<NoteModel> NotesCollection { get; }

        //public Command SaveNoteCommand { get; }
        //public Command EraseNotesCommand { get; }
    }
}
