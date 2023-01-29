using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Hotell567.Logic;
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
    private async Task GetRoomsAsync()
    {
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
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            IsBusy = false;
        }
    }

}