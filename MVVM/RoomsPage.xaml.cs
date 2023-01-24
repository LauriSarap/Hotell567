using Hotell567.Models;

namespace Hotell567.MVVM;

public partial class RoomsPage : ContentPage
{
	public RoomsPage(RoomViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(RoomsPage));
		//DisplayAlert("Alert", "This function works", "OK");
    }
}
