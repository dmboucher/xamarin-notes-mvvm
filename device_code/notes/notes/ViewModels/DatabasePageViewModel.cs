using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using SQLite;

namespace notes
{
    public class DatabasePageViewModel : INotifyPropertyChanged
    {
        // Properties
        public INavigation Navigation { get; set; }
        public Command<TableModel> TableSchemaCommand { get; }
        public Command<TableModel> TableRecordsCommand { get; }
        public Command TableMappingCommand { get; }

        public List<TableModel> TableListViewable { get; set; }

        private List<TableModel> tableList;
        public List<TableModel> TableList 
        {
            get => tableList;
            set
            {
                tableList = value;
                OnPropertyChanged(nameof(TableList));
            }
        }

        private TableModel selectedTable;
        public TableModel SelectedTable
        {
            get => selectedTable;
            set
            {
                selectedTable = value;
                OnPropertyChanged(nameof(SelectedTable));
            }
        }

        private List<SQLiteConnection.ColumnInfo> tableInfo;
        public List<SQLiteConnection.ColumnInfo> TableInfo
        {
            get => tableInfo;
            set
            {
                tableInfo = value;
                OnPropertyChanged(nameof(TableInfo));
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


        // Events
        public event PropertyChangedEventHandler PropertyChanged;


        // Constructor
        public DatabasePageViewModel(INavigation navigation)
        {
            // Init
            Navigation = navigation;
            RefreshTableList();


            // Commands
            TableSchemaCommand = new Command<TableModel>(async (tableModel) =>
            {
                SelectedTable = tableModel;
                TableInfo = App.Database.GetTableInfo(SelectedTable.TableName).Result;
                await Navigation.PushAsync(new DatabaseSchemaPage(this)).ConfigureAwait(false);
            });

            TableRecordsCommand = new Command<TableModel>(async (tableModel) =>
            {
                SelectedTable = tableModel;
                NotesListAll = App.Database.GetItemsAsync().Result;
                await Navigation.PushAsync(new DatabaseRecordsPage(this)).ConfigureAwait(false);
            });

            TableMappingCommand = new Command(async () =>
            {
                //****************************** GET RID OF THIS? GET RID OF THE MAPPING BUTTON?
                var x = 1;
            });
        }


        public void RefreshTableList()
        {
            TableList = App.Database.GetTableNames().Result;  // Update the table list.
            TableListViewable = new List<TableModel>();  // Clear the viewable list.
            TableListViewable = TableList;  // Reset the viewable list.
            OnPropertyChanged(nameof(TableListViewable));  // Throw changed event.
        }


        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
