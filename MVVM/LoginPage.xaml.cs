using System.Reflection;
using System.IO;
using Hotell567.Data;
using System.Collections.ObjectModel;
using System;
using Hotell567.Logic;

namespace Hotell567.MVVM;

public partial class LoginPage : ContentPage
{
	public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
    public LoginPage()
	{
		InitializeComponent();
        
        //AppManager.userDatabase = new UserDatabase();
		foreach(var user in AppManager.userDatabase.List())
		{
			Users.Add(user);
		}

        BindingContext = this;


    }

    // Adds to database
    private void LoginBtnClicked(object sender, EventArgs e)
    {
        //TODO Check if user exists, if does, log in, if doesn't, show registration fields and create new user.

        if (AppManager.userFactory.CheckIfAccountFieldsAreValid(usernameEntry.Text, passwordEntry.Text, emailEntry.Text) == true)
        {
            AppManager.userDatabase.SaveUser(new User
            {
                username = usernameEntry.Text,
				password = passwordEntry.Text,
				email = emailEntry.Text
            });

            usernameEntry.Text = string.Empty;
            passwordEntry.Text = string.Empty;
            emailEntry.Text = string.Empty;

            collectionView.ItemsSource = AppManager.userDatabase.List();
        }
        else
        {
            DisplayAlert("Error", "Please enter a valid username, password and email", "OK");
        }
    }

    // Update
    private void UpdateBtnClicked(System.Object sender, EventArgs e)
	{
		if (lastSelection != null)
		{
            AppManager.userDatabase.UpdateUser(lastSelection);
		}
	}

    User lastSelection;

    private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		lastSelection = e.CurrentSelection[0] as User;

		usernameEntry.Text = lastSelection.username;
    }

    // Update
    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        if (lastSelection != null)
        {
            lastSelection.first_name = usernameEntry.Text;
            lastSelection.password = passwordEntry.Text;
            lastSelection.email = emailEntry.Text;
            AppManager.userDatabase.UpdateUser(lastSelection);
        }
    }

    // Delete
    void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        if (lastSelection != null)
        {
            AppManager.userDatabase.DeleteUser(lastSelection);

            AppManager.userDatabase.List();

            usernameEntry.Text = "";
            emailEntry.Text = "";
            passwordEntry.Text = "";
        }
    }
}