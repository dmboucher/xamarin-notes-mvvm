using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace notes
{
    public class NotesPageViewModel : INotifyPropertyChanged
    {
        // Properties
        public INavigation Navigation { get; set; }
        public ObservableCollection<NoteModel> NotesCollection { get; }
        public Command AddNoteCommand { get; }
        public Command NoteSelectedCommand { get; }

        NoteModel selectedNote;
        public NoteModel SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedNote)));
            }
        }

        bool showDoneNotes;
        public bool ShowDoneNotes
        {
            get => showDoneNotes;
            set
            {
                showDoneNotes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowDoneNotes)));
            }
        }


        // Events
        public event PropertyChangedEventHandler PropertyChanged;


        // Constructor
        public NotesPageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            NotesCollection = new ObservableCollection<NoteModel>();
            

            // Commands
            AddNoteCommand = new Command(async () =>
            {
                await navigation.PushAsync(new NotesDetailPage(this)).ConfigureAwait(false);
            });


            NoteSelectedCommand = new Command(async () =>
            {
                if (SelectedNote is null)
                    return;

                //var notesDetailPageViewModel = new NotesDetailPageViewModel()
                //{
                //    //NoteText = SelectedNote.NoteText
                //    // **************************************** SET PROPERTIES NEEDED FOR THE DETAIL PAGE (POSSIBLY JUST THE SELECTED NOTE ID)
                //};

                await navigation.PushAsync(new NotesDetailPage(this)).ConfigureAwait(false);

                SelectedNote = null;
            });
        }
    }
}
