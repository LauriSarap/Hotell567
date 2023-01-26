using System.Data.Entity;
using System.Data.SQLite;

namespace Hotell567.Data
{
    public class UserDatabase
    {

        public UserDatabase()
        {
            
        } 

        public List<User> List()
        {
            using (SQLiteConnection conn = new SQLiteConnection(LoadConnectionString())
            {
                return conn.Table<User>().ToList();
            }
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
