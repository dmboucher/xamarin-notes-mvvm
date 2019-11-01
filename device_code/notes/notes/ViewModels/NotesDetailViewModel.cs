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
                OnPropertyChanged(nameof(LocalId));
            }
        }

        private string noteTitle;
        public string NoteTitle
        {
            get => noteTitle;
            set
            {
                noteTitle = SelectedNote.NoteTitle = value;
                OnPropertyChanged(nameof(NoteTitle));
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
                OnPropertyChanged(nameof(NoteText));
            }
        }

        private bool hasDueDate;
        public bool HasDueDate
        {
            get => hasDueDate;
            set
            {
                hasDueDate = SelectedNote.HasDueDate = value;
                OnPropertyChanged(nameof(HasDueDate));
            }
        }

        private string dueDate;
        public string DueDate
        {
            get => dueDate;
            set
            {
                dueDate = SelectedNote.DueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }

        private bool done;
        public bool Done
        {
            get => done;
            set
            {
                done = SelectedNote.Done = value;
                OnPropertyChanged(nameof(Done));
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
            NoteTitle = SelectedNote.NoteTitle;
            NoteText = SelectedNote.NoteText;
            HasDueDate = SelectedNote.HasDueDate;
            DueDate = SelectedNote.DueDate;
            Done = SelectedNote.Done;
        }


        private void CloseAndRefresh()
        {
            Device.BeginInvokeOnMainThread(async () => await Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false));
            parentViewModel.RefreshNoteList();
        }


        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
