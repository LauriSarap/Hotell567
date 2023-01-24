using Hotell567.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotell567.Data
{
    public class UserRepository
    {
        private readonly SQLiteConnection _database;

        public static string DbPath { get; } =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "hoteldatabase.db");
        public UserRepository()
        {
            _database = new SQLiteConnection(DbPath);
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
