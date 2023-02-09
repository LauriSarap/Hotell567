﻿using System.Data.SQLite;
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

        // Get room by room id
        public async Task<Room> GetRoomById(int room_id)
        {
            using (SQLiteConnection _connection = new SQLiteConnection(AppManager.connectionString))
            {
                _connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Rooms WHERE room_id = @room_id", _connection);
                command.Parameters.AddWithValue("@room_id", room_id);
                var reader = await command.ExecuteReaderAsync();
                var room = new Room();

                while (await reader.ReadAsync())
                {
                    room.room_id = reader["room_id"].GetHashCode();
                    room.room_type = reader["room_type"].ToString();
                    room.room_image_name = reader["room_image_name"].ToString();
                    room.room_description = reader["room_description"].ToString();
                    room.room_availability = reader["room_availability"].ToString();
                    room.room_price_per_night = reader["room_price_per_night"].GetHashCode();
                }

                Debug.Write("Room found from database: " + room.room_id);
                return room;
            }
        }

        // Add reservation
        public async void AddRoom(Room room)
        {
            using (SQLiteConnection _connection = new SQLiteConnection(AppManager.connectionString))
            {
                _connection.Open();
                var command = new SQLiteCommand("INSERT INTO Rooms (room_type, room_image_name, room_description, room_availability, room_price_per_night) VALUES (@room_type, @room_image_name, @room_description, @room_availability, @room_price_per_night)", _connection);
                command.Parameters.AddWithValue("@room_type", room.room_type);
                command.Parameters.AddWithValue("@room_image_name", room.room_image_name);
                command.Parameters.AddWithValue("@room_description", room.room_description);
                command.Parameters.AddWithValue("@room_availability", room.room_availability);
                command.Parameters.AddWithValue("@room_price_per_night", room.room_price_per_night);
                await command.ExecuteNonQueryAsync();

                Debug.Write("Room added to database: " + room.room_id);
            }
        }
    }
}
