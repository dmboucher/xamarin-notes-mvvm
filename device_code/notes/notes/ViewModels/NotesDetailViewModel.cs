using System.ComponentModel;
using Xamarin.Forms;

namespace notes
{
    public class NotesDetailPageViewModel : INotifyPropertyChanged
    {
        // Properties
        NotesPageViewModel parentViewModel;
        //public ObservableCollection<NoteModel> Notes { get; }
        public Command SaveNoteCommand { get; }
        public Command DeleteNoteCommand { get; }

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


        // Events
        public event PropertyChangedEventHandler PropertyChanged;


        // Constructor
        public NotesDetailPageViewModel(NotesPageViewModel notesPageViewModel)
        {
            parentViewModel = notesPageViewModel;
            //Notes = new ObservableCollection<NoteModel>();


            // Commands
            SaveNoteCommand = new Command(() =>
            {
                var x = parentViewModel;  // YES! WE HAVE PARENT VIEW MODEL CONTEXT HERE!!  WOOT!!
                var y = 1;
                //Notes.Add(new NoteModel { Text = NoteText });

                // Craft object for db
                // Add to db
                // Kick off a list re-load in parent view model
                // Return to NotesPage
            },
            () => !string.IsNullOrEmpty(NoteTitle));


            DeleteNoteCommand = new Command(() =>
            {
                var x = 1;
            });
        }
    }
}
