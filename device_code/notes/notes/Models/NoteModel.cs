using SQLite;

namespace notes
{
    public class NoteModel
    {
        [PrimaryKey, AutoIncrement]
        public int LocalId { get; set; }  // Needed for interacting with SQLite - these values will not leave this device
        
        [NotNull, Unique]
        public string ServerId { get; set; }  // This value will serve as the PK in the warehouse - will use GUID's to avoid key clashes
        
        public string Title { get; set; }
        
        public string NoteText { get; set; }

        public string DueDate { get; set; }

        public bool Done { get; set; }
        
        public bool IsDeleted { get; set; }
        
        [NotNull]
        public string LastUpdated { get; set; }
        
        public string LastSync { get; set; }
    }
}
