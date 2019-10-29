using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace notes
{
    public class NotesPageViewModel : INotifyPropertyChanged
    {
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


        public NotesPageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            NotesCollection = new ObservableCollection<NoteModel>();
            
            AddNoteCommand = new Command(async () =>
            {
                await navigation.PushAsync(new NotesDetailPage(new NotesDetailPageViewModel())).ConfigureAwait(false);
            });

            NoteSelectedCommand = new Command(async () =>
            {
                if (SelectedNote is null)
                    return;

                var notesDetailPageViewModel = new NotesDetailPageViewModel()
                {
                    //NoteText = SelectedNote.NoteText
                    // **************************************** SET PROPERTIES NEEDED FOR THE DETAIL PAGE (POSSIBLY JUST THE SELECTED NOTE ID)
                };

                await navigation.PushAsync(new NotesDetailPage(notesDetailPageViewModel)).ConfigureAwait(false);

                SelectedNote = null;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
