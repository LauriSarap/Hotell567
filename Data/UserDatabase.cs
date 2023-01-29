using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Diagnostics;
using Hotell567.Logic;

namespace Hotell567.Data
{
    public class UserDatabase
    {
        public UserDatabase()
        {
            Debug.WriteLine("UserDatabase created");

            if (File.Exists(AppManager.dbFilePath))
            {
                Debug.WriteLine("Found database!");
            }
            else
            {
                Debug.WriteLine("Failed to find database!");
            }
        }

        // List users
        public List<User> ListUsers()
        {
            using (SQLiteConnection _connection = new SQLiteConnection(AppManager.connectionString))
            {
                _connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Users", _connection);
                var reader = command.ExecuteReader();
                var users = new List<User>();
                
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        user_id = reader["user_id"].GetHashCode(),
                        user_type = reader["user_type"].GetHashCode(),
                        first_name = reader["first_name"].ToString(),
                        last_name = reader["last_name"].ToString(),
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString(),
                        email = reader["email"].ToString()
                    });
                }
                return users;
            }
        }

        public User GetUserById(int user_id)
        {
            using (SQLiteConnection _connection = new SQLiteConnection(AppManager.connectionString))
            {
                _connection.Open();
                User u = new User();

                var command = new SQLiteCommand("SELECT * FROM Users WHERE user_id = @user_id", _connection);
                command.Parameters.AddWithValue("@user_id", user_id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    u.user_id = reader["user_id"].GetHashCode();
                    u.user_type = reader["user_type"].GetHashCode();
                    u.first_name = reader["first_name"].ToString();
                    u.last_name = reader["last_name"].ToString();
                    u.username = reader["username"].ToString();
                    u.password = reader["password"].ToString();
                    u.email = reader["email"].ToString();
                    u.phone_number = reader["phone_number"].GetHashCode();
                    u.date_of_birth = reader["date_of_birth"].ToString();
                    u.address_line_1 = reader["address_line_1"].ToString();
                    u.address_line_2 = reader["address_line_2"].ToString();
                    u.city = reader["city"].ToString();
                    u.state = reader["state"].ToString();
                    u.postal_code = reader["postal_code"].GetHashCode();
                    u.country = reader["country"].ToString();
                }
                return u;
            }
        }

        public User CheckDBForUser(string username)
        {
            using (SQLiteConnection _connection = new SQLiteConnection(AppManager.connectionString))
            {
                _connection.Open();
                User u = new User();

                var command = new SQLiteCommand("SELECT * FROM Users WHERE username = @username", _connection);
                command.Parameters.AddWithValue("@username", username);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    u.username = reader["username"].ToString();
                    u.password = reader["password"].ToString();
                    u.user_id = reader["user_id"].GetHashCode();
                }
                return u;
            }
        }

        public User CheckDBForUserType(string username)
        {
            using (SQLiteConnection _connection = new SQLiteConnection(AppManager.connectionString))
            {
                _connection.Open();
                User u = new User();

                var command = new SQLiteCommand("SELECT * FROM Users WHERE username = @username", _connection);
                command.Parameters.AddWithValue("@username", username);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    u.username = reader["username"].ToString();
                    u.user_type = reader["user_type"].GetHashCode();
                }
                return u;
            }
        }

        public void AddUser(User u)
        {
            using (SQLiteConnection _connection = new SQLiteConnection(AppManager.connectionString))
            {
                _connection.Open();
                var command = new SQLiteCommand("INSERT INTO Users (username, password, email) VALUES (@username, @password, @email)", _connection);
                command.Parameters.AddWithValue("@username", u.username);
                command.Parameters.AddWithValue("@password", u.password);
                command.Parameters.AddWithValue("@email", u.email);
                command.ExecuteNonQuery();
            }
        }
    }
}
