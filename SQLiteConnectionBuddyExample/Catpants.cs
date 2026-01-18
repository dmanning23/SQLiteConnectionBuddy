using SQLite;

namespace SQLiteConnectionBuddyExample
{
    [Table("Cats")]
    public class Catpants
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(32)]
        public string Name { get; set; }

        public int Number { get; set; }
    }
}
