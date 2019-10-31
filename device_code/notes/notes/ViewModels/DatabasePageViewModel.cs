using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace notes
{
    public class DatabasePageViewModel : INotifyPropertyChanged
    {
        // Properties
        public INavigation Navigation { get; set; }
        public Command TableMappingCommand { get; }

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
        public DatabasePageViewModel(INavigation navigation)
        {
            // Init
            Navigation = navigation;


            // Commands
            TableMappingCommand = new Command(async () =>
            {
                var x = 1;
            });
        }


        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
