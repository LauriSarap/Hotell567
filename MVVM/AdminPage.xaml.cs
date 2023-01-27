using System.Collections.ObjectModel;
using System.Diagnostics;
using Hotell567.Data;
using Hotell567.Logic;

namespace Hotell567.MVVM;

public partial class AdminPage : ContentPage
{
    public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

    public AdminPage()
	{
		InitializeComponent();
        UpdateUserList();

        BindingContext = this;
    }

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

    private void OnUserSelected(object sender, EventArgs e)
    {
        Debug.WriteLine("Selected user: " + ((ListView)sender).SelectedItem);
    }

}