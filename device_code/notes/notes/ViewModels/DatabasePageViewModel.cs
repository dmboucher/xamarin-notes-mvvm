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


        // Events
        public event PropertyChangedEventHandler PropertyChanged;


        // Constructor
        public DatabasePageViewModel(INavigation navigation)
        {
            // Init
            Navigation = navigation;
            RefreshTableList();

            //AddProgressToChallengeCommand = new Command<Challenge>((challenge) =>
            //doSomething(challenge);

            // Commands
            TableSchemaCommand = new Command<TableModel>(async (tableModel) =>
            {
                SelectedTable = tableModel;
                var tableInfo = await App.Database.GetTableInfo(SelectedTable.TableName).ConfigureAwait(false);
                var x = 1;
            });

            TableRecordsCommand = new Command<TableModel>(async (tableModel) =>
            {
                var x = 1;
            });

            TableMappingCommand = new Command(async () =>
            {
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
