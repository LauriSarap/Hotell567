using System.Diagnostics;
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
        if (AppManager.currentUser == null)
        {
            await DisplayAlert("Error", "You must log in to make a reservation!", "Okay, I will");
            return;
        }

        if (AppManager.userFactory.CheckIfUserCanBook() == false)
        {
            await DisplayAlert("Account not fully registered!", "You must fill out all fields in your account settings to make a reservation", "Okay, I will");
            return;
        }

        if (AppManager.reservationFactory.IsCheckInDateValid(CheckInDate.Date) == false)
        {
            await DisplayAlert("Error", "Check-in date must be in the future", "OK");
            return;
        }

        if (AppManager.reservationFactory.AreDatesValid(CheckInDate.Date, CheckOutDate.Date) == false)
        {
            await DisplayAlert("Error", "Check-out date must be after check-in date", "OK");
            return;
        }

        bool isRoomAvailable = await AppManager.reservationFactory.IsRoomAvailable(viewModel.Room.room_id, CheckInDate.Date, CheckOutDate.Date);

        if (isRoomAvailable == false)
        {
            await DisplayAlert("Error", "Room is not available for the selected dates", "OK");
            return;
        }

        AppManager.reservationFactory.CreateReservation(CheckInDate.Date, CheckOutDate.Date, viewModel.Room.room_id, AppManager.currentUser.user_id);

        await DisplayAlert("Success", $"Reservation from {CheckInDate.Date.Date} until {CheckOutDate.Date.Date} created", "OK");
    }

    private void CheckInDateChanged(object sender, EventArgs e)
    {
        if (CheckInDate == null) return;

        Debug.WriteLine("CheckInDateChanged");

        if (CheckInDate.Date == DateTime.Today || CheckOutDate.Date == DateTime.Today)
        {
            return;
        }

        if (CheckInDate.Date > CheckOutDate.Date)
        { 
            return;
        }

        if (CheckInDate.Date == CheckOutDate.Date)
        {
            return;
        }

        NumberOfNightsText.Text = $"Number of nights: {(CheckOutDate.Date - CheckInDate.Date).Days}";

        decimal price = AppManager.reservationFactory.CalculateReservationTotalPrice(CheckInDate.Date, CheckOutDate.Date, viewModel.Room.room_id).Result;

        ExpectedPriceText.Text = $"Total price: {price}�";
    }

    private void CheckOutDateChanged(object sender, EventArgs e)
    {
        if (CheckOutDate == null) return;

        Debug.WriteLine("CheckOutDateChanged");

        if (CheckInDate.Date == DateTime.Today || CheckOutDate.Date == DateTime.Today)
        {
            return;
        }

        if (CheckInDate.Date > CheckOutDate.Date)
        {
            return;
        }

        if (CheckInDate.Date == CheckOutDate.Date)
        {
            return;
        }

        NumberOfNightsText.Text = $"Number of nights: {(CheckOutDate.Date - CheckInDate.Date).Days}";

        decimal price = AppManager.reservationFactory.CalculateReservationTotalPrice(CheckInDate.Date, CheckOutDate.Date, viewModel.Room.room_id).Result;

        ExpectedPriceText.Text = $"Total price: {price}�";
    }
}