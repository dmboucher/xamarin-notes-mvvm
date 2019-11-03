using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace notes
{
    public class DatabaseRecordsPagelViewModel : INotifyPropertyChanged
    {
        // Properties
        DatabasePageViewModel parentViewModel;
        public INavigation Navigation { get; set; }

        private ObservableCollection<NoteModel> notesListAll;
        public ObservableCollection<NoteModel> NotesListAll
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

            // Convert List to Observable Collection for the Carousel Page Data Binding
            NotesListAll = new ObservableCollection<NoteModel>();
            foreach (var note in parentViewModel.NotesListAll)
            {
                NotesListAll.Add(note);
            }
        }


        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
