using System.Diagnostics;
using Hotell567.Models;

namespace Hotell567.Logic
{
    public class RoomFiltering
    {
        public List<Room> Rooms { get; set; } = new ();
        public List<Reservation> Reservations { get; set; } = new();

        public RoomFiltering()
        {
            Debug.WriteLine("RoomFiltering created");
        }

        public void UpdateRoomAndReservationList()
        {
            Rooms = AppManager.roomDatabase.ListRooms().Result;
            Reservations = AppManager.reservationDatabase.ListReservations().Result;
        }

        public List<Room> FilterRooms(string roomType, int minPrice, int maxPrice, DateTime startDate, DateTime endDate)
        {

            // Filter the rooms by room type
            List<Room> filteredRoomsByType = new List<Room>();
            if (roomType != "All")
            {
                filteredRoomsByType = FilterByRoomType(roomType);
            }
            else if (roomType == "All")
            {
                filteredRoomsByType = Rooms;
            }

            // Filter the rooms by room price
            if (maxPrice == 0)
            {
                FilterByRoomPrice(filteredRoomsByType, minPrice, 9999999);
            }
            else
            {
                filteredRoomsByType = FilterByRoomPrice(filteredRoomsByType, minPrice, maxPrice);
            }

            // Filter the rooms by date
            if (startDate == DateTime.Today && endDate == DateTime.Today)
            {
                return filteredRoomsByType;
            }
            else
            {
                filteredRoomsByType = FilterByAvailability(filteredRoomsByType, startDate, endDate);
            }

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
                foreach (var reservation in Reservations)
                {
                    if (room.room_id == reservation.res_room_id)
                    {
                        if (startDate >= reservation.res_check_in_date && endDate <= reservation.res_check_out_date)
                        {
                            Console.WriteLine($"Room {room.room_id} is not available on these dates!");
                        }
                        else if (endDate >= reservation.res_check_in_date && endDate <= reservation.res_check_out_date)
                        {
                            Console.WriteLine($"Room {room.room_id} is not available on these dates!");
                        }
                        else
                        {
                            Console.WriteLine($"Room {room.room_id} is available on these dates!");
                            filteredRooms.Add(room);
                        }
                    }
                }
            }

            return filteredRooms;
        }
    }
}
