using System.Data.SQLite;

namespace Hotell567.Data
{
    public class RoomDatabase
    {
        private readonly SQLiteConnection _database;

        public RoomDatabase(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Room>();
        }

        public List<Room> List()
        {
            return _database.Table<Room>().ToList();
        }

        public int SaveRoom(Room room)
        {
            return _database.Insert(room);
        }

        public int UpdateRoom(Room room)
        {
            return _database.Update(room);
        }

        public int DeleteRoom(Room room)
        {
            return _database.Delete(room);
        }
    }
}
