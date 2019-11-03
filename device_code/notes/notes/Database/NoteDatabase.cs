using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace notes
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection database;

        public NoteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<NoteModel>().Wait();
        }

        public Task<List<NoteModel>> GetItemsAsync()
        {
            return database.Table<NoteModel>().ToListAsync();
        }

        public Task<NoteModel> GetItemAsync(int LocalId)
        {
            return database.Table<NoteModel>().Where(i => i.LocalId == LocalId).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(NoteModel item)
        {
            if (item?.LocalId == 0)
            {
                return database.InsertAsync(item);
            }
            else
            {
                return database.UpdateAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(NoteModel item)
        {
            return database.DeleteAsync(item);
        }

        public Task<List<TableModel>> GetTableNames()
        {
            return database.QueryAsync<TableModel>("SELECT name AS TableName FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%' ORDER BY name;");
        }

        public Task<List<SQLiteConnection.ColumnInfo>> GetTableInfo(string tableName)
        {
            return database.GetTableInfoAsync(tableName);
        }

    }
}
