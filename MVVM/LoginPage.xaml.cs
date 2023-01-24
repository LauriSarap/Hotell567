using System.Reflection;
using System.IO;
using Hotell567.Data;
using System.Collections.ObjectModel;
using Hotell567.Models;
using Hotell567.Data;
using System;

namespace Hotell567.MVVM;

public partial class LoginPage : ContentPage
{
	public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
	public UserRepository userRepository;
	public LoginPage()
	{
		InitializeComponent();

		// TODO only do this when app first runs
		var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
		using (Stream stream = assembly.GetManifestResourceStream("Hotell567.hoteldatabase.db"))
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				stream.CopyTo(memoryStream);

				File.WriteAllBytes(UserRepository.DbPath, memoryStream.ToArray()); 
			}
		}

		userRepository = new UserRepository();
		foreach(var user in userRepository.List())
		{
			Users.Add(user);
		}

		BindingContext = this;

	}

	// Adds to database
    void OnButtonClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(usernameEntry.Text))
		{
			userRepository.SaveUser(new User
            {
                username = usernameEntry.Text,
				password = passwordEntry.Text,
				email = emailEntry.Text
            });

            usernameEntry.Text = string.Empty;

            collectionView.ItemsSource = userRepository.List();
        }
    }

	// Update
	void Button_Clicked(System.Object sender, EventArgs e)
	{
		if(lastSelection != null)
		{
			userRepository.UpdateUser(lastSelection);
		}
	}

    void Button_Clicked_1(System.Object sender, EventArgs e)
    {

    }

    User lastSelection;

    private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		lastSelection = e.CurrentSelection[0] as User;

		usernameEntry.Text = lastSelection.username;
    }
}