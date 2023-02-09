using Hotell567.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Hotell567.Models;
using CommunityToolkit.Mvvm.Input;
using Hotell567.Logic;

namespace Hotell567.MVVM;

public partial class RoomsPage : ContentPage
{
    public ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();


    public RoomsPage(RoomsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    [RelayCommand]
    private async Task GetRoomsAsync()
    {
        // Filter the rooms
        Rooms.Clear();
        AppManager.roomFiltering.UpdateRoomAndReservationList();

        string roomType = RoomTypePicker.SelectedItem.ToString();
        int minPrice;
        int maxPrice;
        DateTime startDate;
        DateTime endDate;

        int minResult;
        if (int.TryParse(MinPrice.Text, out minResult))
        {
            Debug.WriteLine("Min price: " + minResult);
            minPrice = minResult;
        }
        else
        {
            DisplayAlert("Error", "Enter a proper minimum price", "Okay");
            return;
        }

        int maxResult;
        if (int.TryParse(MaxPrice.Text, out maxResult))
        {
            Debug.WriteLine("Max price: " + maxResult);
            maxPrice = maxResult;
        }
        else
        {
            DisplayAlert("Error", "Enter a proper maximum price", "Okay");
            return;
        }

        startDate = StartDate.Date;
        endDate = EndDate.Date;

        List<Room> filteredRooms = AppManager.roomFiltering.FilterRooms(roomType, minPrice, maxPrice, startDate, endDate);
        foreach (var room in filteredRooms)
        {
            Rooms.Add(room);
        }
    }

    private async void LearnMoreBtnClicked(object sender, EventArgs e)
    {
        
        var room = ((VisualElement)sender).BindingContext as Room;

        Debug.WriteLine("Opening room: " + room.room_type + "!");

        if (room == null) return;

        await Shell.Current.GoToAsync(nameof(RoomDetailPage), true, new Dictionary<string, object>
        {
            {"Room", room}
        });
        
    }

    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}
