using System.Data.SQLite;
using System.Diagnostics;
using Hotell567.Logic;
using Hotell567.Models;

namespace Hotell567.Data
{
    public class RoomDatabase
    {
        public RoomDatabase()
        {
            Debug.WriteLine("RoomDatabase connector created");
        }

        // List rooms
        public async Task<List<Room>> ListRooms()
        {
            using (SQLiteConnection _connection = new SQLiteConnection(AppManager.connectionString))
            {
                _connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Rooms", _connection);
                var reader = await command.ExecuteReaderAsync();
                var rooms = new List<Room>();

                while (await reader.ReadAsync())
                {
                    rooms.Add(new Room
                    {
                        room_id = reader["room_id"].GetHashCode(),
                        room_type = reader["room_type"].ToString(),
                        room_image_name = reader["room_image_name"].ToString(),
                        room_description = reader["room_description"].ToString(),
                        room_availability = reader["room_availability"].ToString(),
                        room_price_per_night = reader["room_price_per_night"].GetHashCode()
                    });
                }

                Debug.Write("Rooms found from database: " + rooms.Count);
                return rooms;
            }
        }

    }
}
