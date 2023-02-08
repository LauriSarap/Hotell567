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

    private string roomTypeFilter;
    private string roomPricePerNightMinFilter;
    private string roomPricePerNightMaxFilter;
    private string roomStartDateFilter;
    private string roomEndDateFilter;


    public RoomsPage(RoomsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    /* [RelayCommand]
    private async Task GetRoomsAsync()
    {
        // Filter the rooms
        Rooms.Clear();
        AppManager.roomFiltering.UpdateRoomAndReservationList();

        RoomTypePicker.SelectedItem
    }*/

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
