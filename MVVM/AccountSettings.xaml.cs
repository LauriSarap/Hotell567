using Hotell567.Logic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Hotell567.Models;

namespace Hotell567.MVVM;

public partial class AccountSettings : ContentPage
{
    private static AccountSettings accountSettingsSingleton;

    public User CurrentUser { get; set; }

    public AccountSettings()
	{
		InitializeComponent();
        accountSettingsSingleton = this;
        UpdateCurrentUser();
        BindingContext = this;
    }

    public static AccountSettings GetSingleton
    {
        get
        {
            return accountSettingsSingleton;
        }
    }

    public void UpdateCurrentUser()
    {
        CurrentUser = AppManager.currentUser;
    }

    private void SaveBtnClicked(object sender, EventArgs e)
    {
        /*if (string.IsNullOrEmpty())
        {
            await DisplayAlert("Error", "Please enter a username", "OK");
            return;
        }

        if (string.IsNullOrEmpty(emailEntry.Text))
        {
            await DisplayAlert("Error", "Please enter an email address", "OK");
            return;
        }

        if (string.IsNullOrEmpty(passwordEntry.Text))
        {
            await DisplayAlert("Error", "Please enter a password", "OK");
            return;
        }

        if (passwordEntry.Text != confirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Passwords do not match", "OK");
            return;
        }
        
        //update the account settings
        try
        {
            await DisplayAlert("Account updated", "YAY", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }*/
    }
}