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
        public NotesDetailPageViewModel()
        {
            Notes = new ObservableCollection<NoteModel>();

            SaveNoteCommand = new Command(() =>
            {
                //Notes.Add(new NoteModel { Text = NoteText });  // Adding to db
                //NoteText = string.Empty;                       // Clearing form
                var x = 1;
            },
            () => !string.IsNullOrEmpty(NoteTitle));

            DeleteNoteCommand = new Command(() =>
            {
                var x = 1;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        string noteTitle;
        public string NoteTitle
        {
            get => noteTitle;
            set 
            { 
                noteTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteTitle)));
                SaveNoteCommand.ChangeCanExecute();
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

        bool hasDueDate;
        public bool HasDueDate
        {
            get => hasDueDate;
            set 
            { 
                hasDueDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasDueDate))); 
            }
        }

        string dueDate;
        public string DueDate
        {
            get => dueDate;
            set 
            { 
                dueDate = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DueDate))); 
            }
        }

        string done;
        public string Done
        {
            get => done;
            set 
            { 
                done = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Done))); 
            }
        }


        public ObservableCollection<NoteModel> Notes { get; }
        public Command SaveNoteCommand { get; }
        public Command DeleteNoteCommand { get; }
    }
}
