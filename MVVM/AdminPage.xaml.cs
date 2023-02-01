using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Hotell567.Logic;
using Hotell567.Models;
using Microsoft.Maui.Controls.Compatibility;

namespace Hotell567.MVVM;

public partial class AdminPage : ContentPage
{
    public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
    public ObservableCollection<Reservation> Reservations { get; set; } = new ();

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

    private void GetReservationUser()
    {
        foreach (var reservation in Reservations)
        {
            User user = AppManager.userDatabase.GetUserById(reservation.res_user_id);
            Users.Add(user);
        }
    }


    // Users stuff

    private void UpdateUserListBtn(object sender, EventArgs e)
    {
        UpdateUserList();
    }

    public void UpdateUserList()
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