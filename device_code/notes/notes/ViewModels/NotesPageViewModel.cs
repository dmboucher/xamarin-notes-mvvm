using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace notes
{
    public class NotesPageViewModel : INotifyPropertyChanged
    {
        // Properties
        public INavigation Navigation { get; set; }
        public Command AddNoteCommand { get; }
        public Command NoteSelectedCommand { get; }
        public Command NotesListRefreshCommand { get; }

        public List<NoteModel> NotesListViewable { get; set; }

        public List<NoteModel> NotesListNotDone
        {
            get
            {
                return NotesListAll.Where(x => x.Done == false && x.IsDeleted == false).ToList();
            }
        }

        public List<NoteModel> NotesListIncludingDone
        {
            get
            {
                return NotesListAll.Where(x => x.IsDeleted == false).ToList();
            }
        }

        private List<NoteModel> notesListAll;
        public List<NoteModel> NotesListAll 
        {
            get => notesListAll;
            set
            {
                notesListAll = value;
                OnPropertyChanged(nameof(NotesListAll));
            }
        }

        private NoteModel selectedNote;
        public NoteModel SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                OnPropertyChanged(nameof(SelectedNote));
            }
        }

        private bool showDoneNotes;
        public bool ShowDoneNotes
        {
            get => showDoneNotes;
            set
            {
                showDoneNotes = value;
                NotesListViewable = showDoneNotes ? NotesListIncludingDone : NotesListNotDone;
                OnPropertyChanged(nameof(ShowDoneNotes));
                OnPropertyChanged(nameof(NotesListViewable));
            }
        }


        // Events
        public event PropertyChangedEventHandler PropertyChanged;


        // Constructor
        public NotesPageViewModel(INavigation navigation)
        {
            // Init
            Navigation = navigation;
            RefreshNoteList();
            NotesListViewable = NotesListNotDone;


            // Commands
            AddNoteCommand = new Command(async () =>
            {
                SelectedNote = new NoteModel  // Set selected Note to a new, empty Note.
                {
                    ServerId = Guid.NewGuid().ToString()
                };
                await navigation.PushAsync(new NotesDetailPage(this)).ConfigureAwait(false);
            });


            NoteSelectedCommand = new Command(async () =>
            {
                await navigation.PushAsync(new NotesDetailPage(this)).ConfigureAwait(false);
            });
        }


        public void RefreshNoteList()
        {
            NotesListAll = App.Database.GetItemsAsync().Result;  // Update the overall list.
            NotesListViewable = new List<NoteModel>();  // Clear the viewable list.
            NotesListViewable = showDoneNotes ? NotesListIncludingDone : NotesListNotDone;  // Reset the viewable list.
            OnPropertyChanged(nameof(NotesListViewable));
        }


        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
