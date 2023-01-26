using System.Data.SQLite;

namespace Hotell567.Data
{
    public class UserDatabase
    {
        private readonly SQLiteConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<User>();
        } 

        public List<User> List()
        {
            return _database.Table<User>().ToList();
        }

        public int SaveUser(User user)
        {
            return _database.Insert(user);
        }

        public int UpdateUser(User user)
        {
            return _database.Update(user);
        }

        public int DeleteUser(User user)
        {
            return _database.Delete(user);
        }
    }
}
