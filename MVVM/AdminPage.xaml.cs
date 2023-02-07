using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Hotell567.Logic;
using Hotell567.Models;

namespace Hotell567.MVVM;

public partial class AdminPage : ContentPage
{
    public ObservableCollection<User> Users { get; set; } = new ();
    public ObservableCollection<Reservation> Reservations { get; set; } = new ();
    public ObservableCollection<Room> Rooms { get; set; } = new();

    public AdminPage()
	{
		InitializeComponent();
        UpdateUserList();

        BindingContext = this;
    }

    // Reservations stuff

    [RelayCommand]
    private async Task GetReservationsAsync()
    {
        try
        {
            List<Reservation> reservations = await AppManager.reservationDatabase.ListReservations();

            if (Reservations.Count != 0) Reservations.Clear();

            foreach (Reservation reservation in reservations)
            {
                Reservations.Add(reservation);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unable to get reservations: {e.Message}");
            throw;
        }
    }

    [RelayCommand]
    private async Task GetRoomsAsync()
    {
        try
        {
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
    }

    private void SelectUser(object sender, EventArgs e)
    {
        Reservation selectedReservation = (Reservation)((Button)sender).BindingContext;

        UpdateUserList();
        User selectedUser = Users.FirstOrDefault(u => u.user_id == selectedReservation.res_user_id);

        Debug.WriteLine("Selected reservation's username: " + selectedUser.username);
        this.ShowPopupAsync(new AdminUserInformationPopup(selectedUser));
    }


    // Users stuff if comes some day

    private void UpdateUserListBtn(object sender, EventArgs e)
    {
        UpdateUserList();
    }

    public async void UpdateUserList()
    {
        var usersFromDb = AppManager.userDatabase.ListUsers();

        foreach (var user in usersFromDb)
        {
            if (!Users.Any(u => u.user_id == user.user_id))
            {
                Debug.WriteLine("Didn't find " + user.username + " and added it");
                Users.Add(user);
            }
            else
            {
                Debug.WriteLine("Found: " + user.username);
            }
        }
    }
}