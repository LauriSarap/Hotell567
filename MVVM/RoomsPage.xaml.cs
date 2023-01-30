using Hotell567.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Hotell567.Models;

namespace Hotell567.MVVM;

public partial class RoomsPage : ContentPage
{
    public ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();

    public RoomsPage(RoomsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
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
}
