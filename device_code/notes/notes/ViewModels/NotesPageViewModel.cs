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

        public List<NoteModel> NotesListViewable { get; set; }

        public List<NoteModel> NotesListNotDone
        {
            get
            {
                return NotesListAll.Where(x => x.Done == false).ToList();
            }
        }

        public List<NoteModel> NotesListAll
        {
            get
            {
                return App.Database.GetItemsAsync().Result;
            }
        }

        private NoteModel selectedNote;
        public NoteModel SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedNote)));
            }
        }

        private bool showDoneNotes;
        public bool ShowDoneNotes
        {
            get => showDoneNotes;
            set
            {
                showDoneNotes = value;
                NotesListViewable = showDoneNotes ? NotesListAll : NotesListNotDone;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowDoneNotes)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NotesListViewable)));
            }
        }


        // Events
        public event PropertyChangedEventHandler PropertyChanged;


        // Constructor
        public NotesPageViewModel(INavigation navigation)
        {
            // Init
            Navigation = navigation;
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
    }
}
