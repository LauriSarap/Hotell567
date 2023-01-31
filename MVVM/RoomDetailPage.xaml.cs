using Hotell567.Data;
using Hotell567.Logic;

namespace Hotell567.MVVM;

public partial class RoomDetailPage : ContentPage
{
    private RoomDetailViewModel viewModel;
    
    public RoomDetailPage()
    {
        InitializeComponent();
        viewModel = new RoomDetailViewModel();
        BindingContext = viewModel;
    }


    public async void BookBtnClicked(object sender, EventArgs e)
    {
        if (AppManager.reservationFactory.IsCheckInDateValid(CheckInDate.Date) == false)
        {
            DisplayAlert("Error", "Check-in date must be in the future", "OK");
            return;
        }

        if (AppManager.reservationFactory.AreDatesValid(CheckInDate.Date, CheckOutDate.Date) == false)
        {
            DisplayAlert("Error", "Check-out date must be after check-in date", "OK");
            return;
        }

        bool isRoomAvailable = await AppManager.reservationFactory.IsRoomAvailable(viewModel.Room.room_id, CheckInDate.Date, CheckOutDate.Date);

        if (isRoomAvailable == false)
        {
            DisplayAlert("Error", "Room is not available for the selected dates", "OK");
            return;
        }

        AppManager.reservationFactory.CreateReservation(CheckInDate.Date, CheckOutDate.Date, viewModel.Room.room_id, AppManager.currentUser.user_id);
        DisplayAlert("Success", $"Reservation from {CheckInDate.Date.ToString()} until {CheckOutDate.Date.ToString()} created", "OK");
        return;
    }
}