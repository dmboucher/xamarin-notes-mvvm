using System;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace notes
{
    public class NotesDetailPageViewModel : INotifyPropertyChanged
    {
        // TODO:  Refactor to bind directly to SelectedNote instead of binding to individual properties.


        // Properties
        NotesPageViewModel parentViewModel;
        public Command SaveNoteCommand { get; }
        public Command DeleteNoteCommand { get; }

        public NoteModel SelectedNote { get; set; }

        private bool CanDelete()
        {
            return LocalId != 0;
        }

        private int localId;
        public int LocalId
        {
            get => localId;
            set
            {
                localId = SelectedNote.LocalId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocalId)));
            }
        }

        private string noteTitle;
        public string NoteTitle
        {
            get => noteTitle;
            set
            {
                noteTitle = SelectedNote.NoteTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteTitle)));
                SaveNoteCommand.ChangeCanExecute();
            }
        }

        private string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = SelectedNote.NoteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
            }
        }

        private bool hasDueDate;
        public bool HasDueDate
        {
            get => hasDueDate;
            set
            {
                hasDueDate = SelectedNote.HasDueDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasDueDate)));
            }
        }

        private string dueDate;
        public string DueDate
        {
            get => dueDate;
            set
            {
                dueDate = SelectedNote.DueDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DueDate)));
            }
        }

        private bool done;
        public bool Done
        {
            get => done;
            set
            {
                done = SelectedNote.Done = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Done)));
            }
        }


        // Events
        public event PropertyChangedEventHandler PropertyChanged;


        // Constructor
        public NotesDetailPageViewModel(NotesPageViewModel notesPageViewModel)
        {
            // Init
            parentViewModel = notesPageViewModel;
            SelectedNote = notesPageViewModel.SelectedNote;


            // Commands
            SaveNoteCommand = new Command(async () =>
            {
                SelectedNote.LastUpdated = DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm", CultureInfo.InvariantCulture);
                await App.Database.SaveItemAsync(SelectedNote).ConfigureAwait(false);
                CloseAndRefresh();
            },
            () => !string.IsNullOrEmpty(SelectedNote.NoteTitle));


            DeleteNoteCommand = new Command(async () =>
            {
                SelectedNote.LastUpdated = DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm", CultureInfo.InvariantCulture);
                SelectedNote.IsDeleted = true;
                await App.Database.SaveItemAsync(SelectedNote).ConfigureAwait(false);
                CloseAndRefresh();
            }, CanDelete);


            // Load ViewModel properties from the SelectedNote - this must come after the command declarations above.
            InitViewModel();
        }


        // Private helper methods
        private void InitViewModel()
        {
            LocalId = SelectedNote.LocalId;
            //ServerId = SelectedNote.ServerId;
            NoteTitle = SelectedNote.NoteTitle;
            NoteText = SelectedNote.NoteText;
            HasDueDate = SelectedNote.HasDueDate;
            DueDate = SelectedNote.DueDate;
            Done = SelectedNote.Done;
            //IsDeleted = SelectedNote.IsDeleted;
            //LastUpdated = SelectedNote.LastUpdated;
            //LastSync = SelectedNote.LastSync;
        }


        private void CloseAndRefresh()
        {
            Device.BeginInvokeOnMainThread(async () => await Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false));
            parentViewModel.RefreshNoteList();
        }
    }
}
