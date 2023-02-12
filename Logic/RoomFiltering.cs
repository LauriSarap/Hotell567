using Hotell567.Models;
using System.Diagnostics;

namespace Hotell567.Logic
{
    public class RoomFiltering
    {
        public List<Room> Rooms { get; set; } = new();
        public List<Reservation> Reservations { get; set; } = new();

        public RoomFiltering()
        {
            Debug.WriteLine("RoomFiltering connector created");
        }

        public void UpdateRoomAndReservationList()
        {
            Rooms = AppManager.roomDatabase.ListRooms().Result;
            Reservations = AppManager.reservationDatabase.ListReservations().Result;

            Debug.WriteLine($"RoomFiltering updated, found {Rooms.Count} rooms and {Reservations.Count} reservations!");
        }

        public List<Room> FilterRooms(string roomType, int minPrice, int maxPrice, DateTime startDate, DateTime endDate)
        {
            // Filter the rooms by room type
            List<Room> filteredRoomsByType = new List<Room>();
            if (roomType != "Any")
            {
                filteredRoomsByType = FilterByRoomType(roomType);
                Debug.WriteLine($"In room filtering getting rooms with type {roomType}, found {filteredRoomsByType.Count}!");
            }
            else if (roomType == "Any")
            {
                filteredRoomsByType = Rooms;
                Debug.WriteLine($"In room filtering getting all room types, found {filteredRoomsByType.Count}!");
            }

            // Filter the rooms by room price
            if (maxPrice == 0)
            {
                filteredRoomsByType = FilterByRoomPrice(filteredRoomsByType, minPrice, 9999999);
                Debug.WriteLine($"In room filtering getting all rooms in the price range, no maximum price, found {filteredRoomsByType.Count}!");
            }
            else
            {
                filteredRoomsByType = FilterByRoomPrice(filteredRoomsByType, minPrice, maxPrice);
                Debug.WriteLine($"In room filtering getting all rooms in the price range, found {filteredRoomsByType.Count}!");
            }

            // Filter the rooms by date
            filteredRoomsByType = FilterByAvailability(filteredRoomsByType, startDate, endDate);
            Debug.WriteLine($"In room filtering getting all rooms available on these dates, found {filteredRoomsByType.Count}!");

            return filteredRoomsByType;
        }

        public List<Room> FilterByRoomType(string roomType)
        {
            // Filter the rooms by room type
            List<Room> filteredRooms = Rooms.Where(room => room.room_type == roomType).ToList();
            return filteredRooms;
        }

        public List<Room> FilterByRoomPrice(List<Room> roomsWithSpeciicType, int minPrice, int maxPrice)
        {
            // Filter the rooms by room price
            List<Room> filteredRooms = roomsWithSpeciicType.Where(room => room.room_price_per_night >= minPrice && room.room_price_per_night <= maxPrice).ToList();
            return filteredRooms;
        }

        public List<Room> FilterByAvailability(List<Room> alreadyFilteredRooms, DateTime startDate, DateTime endDate)
        {
            List<Room> filteredRooms = new List<Room>();

            foreach (var room in alreadyFilteredRooms)
            {
                bool isAvailable = true;

                foreach (var reservation in Reservations)
                {
                    if (room.room_id == reservation.res_room_id)
                    {
                        if (startDate >= reservation.res_check_in_date && endDate <= reservation.res_check_out_date)
                        {
                            Console.WriteLine($"Room {room.room_id} is not available on these dates!");
                            isAvailable = false;
                            break;
                        }
                        if (endDate >= reservation.res_check_in_date && endDate <= reservation.res_check_out_date)
                        {
                            Console.WriteLine($"Room {room.room_id} is not available on these dates!");
                            isAvailable = false;
                            break;
                        }
                        if (startDate >= reservation.res_check_in_date && startDate <= reservation.res_check_out_date)
                        {
                            Console.WriteLine($"Room {room.room_id} is not available on these dates!");
                            isAvailable = false;
                            break;
                        }
                        if (startDate <= reservation.res_check_in_date && endDate >= reservation.res_check_out_date)
                        {
                            Console.WriteLine($"Room {room.room_id} is not available on these dates!");
                            isAvailable = false;
                            break;
                        }

                        if (startDate <= reservation.res_check_in_date && endDate >= reservation.res_check_in_date)
                        {
                            Console.WriteLine($"Room {room.room_id} is not available on these dates!");
                            isAvailable = false;
                            break;
                        }
                    }
                }

                if (isAvailable)
                {
                    Console.WriteLine($"Room {room.room_id} is available on these dates!");
                    filteredRooms.Add(room);
                }
            }

            return filteredRooms;
        }
    }
}
