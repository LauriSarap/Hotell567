using Hotell567.Data;
using System.Collections.ObjectModel;

namespace Hotell567.MVVM;

public partial class RoomsPage : ContentPage
{
    public ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();

    public RoomsPage(RoomsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	
    /*async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(RoomsPage));
		//DisplayAlert("Alert", "This function works", "OK");
    }*/
}
