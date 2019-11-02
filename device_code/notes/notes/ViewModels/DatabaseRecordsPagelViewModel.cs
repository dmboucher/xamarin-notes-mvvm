using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using SQLite;

namespace notes
{
    public class DatabaseRecordsPagelViewModel : INotifyPropertyChanged
    {
        // Properties
        DatabasePageViewModel parentViewModel;
        public INavigation Navigation { get; set; }

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


        // Events
        public event PropertyChangedEventHandler PropertyChanged;


        // Constructor
        public DatabaseRecordsPagelViewModel(DatabasePageViewModel databasePageViewModel)
        {
            // Init
            parentViewModel = databasePageViewModel;
            NotesListAll = parentViewModel.NotesListAll;
        }


        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
