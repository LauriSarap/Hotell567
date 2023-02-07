using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Hotell567.Logic;
using Hotell567.Models;
using Hotell567.MVVM;

namespace Hotell567.Data;

public partial class RoomsViewModel : BaseViewModel
{
    public ObservableCollection<Room> Rooms { get; } = new ();

    public RoomsViewModel()
    {
        Title = "Rooms";
    }

    [RelayCommand]
    private async Task GoToDetails(Room room)
    {
        if (room == null)
            return;

        await Shell.Current.GoToAsync(nameof(RoomDetailPage), true, new Dictionary<string, object>
        {
            {"Room", room }
        });
    }

    [RelayCommand]
    private async Task GetRoomsAsync()
    {
        // Filter the rooms
        /*Rooms.Clear();
        AppManager.roomFiltering.UpdateRoomAndReservationList();

        List<Room> filteredRooms;
        filteredRooms.Ad = AppManager.roomFiltering.
        */

        if (IsBusy) return;

        try
        {
            IsBusy = true;
            List<Room> rooms = await AppManager.roomDatabase.ListRooms();

            if (Rooms.Count != 0) Rooms.Clear();

            foreach (Room room in rooms)
            {
                Rooms.Add(room);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unable to get rooms: {e.Message}");
            throw;
        }
        finally
        {
            IsBusy = false;
        }
    }

}