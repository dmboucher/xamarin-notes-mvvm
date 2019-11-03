using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using SQLite;

namespace notes
{
    public class DatabaseSchemaPagelViewModel : INotifyPropertyChanged
    {
        // Properties
        DatabasePageViewModel parentViewModel;
        public INavigation Navigation { get; set; }
        public Command DismissCommand { get; }

        public List<SQLiteConnection.ColumnInfo> TableInfo { get; set; }


        private string tableDisplayName;
        public string TableDisplayName
        {
            get => $"Schema for {tableDisplayName} table:";
            set
            {
                tableDisplayName = value;
                OnPropertyChanged(nameof(TableDisplayName));
            }
        }


        // Events
        public event PropertyChangedEventHandler PropertyChanged;


        // Constructor
        public DatabaseSchemaPagelViewModel(DatabasePageViewModel databasePageViewModel)
        {
            // Init
            parentViewModel = databasePageViewModel;
            TableInfo = parentViewModel.TableInfo;
            TableDisplayName = parentViewModel.SelectedTable.TableName;
        }


        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
