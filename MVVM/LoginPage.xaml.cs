using System.Reflection;
using System.IO;
using Hotell567.Data;
using System.Collections.ObjectModel;
using Hotell567.Models;

namespace Hotell567.MVVM;

public partial class LoginPage : ContentPage
{
	public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
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

		UserRepository repository = new UserRepository();
		foreach(var user in repository.List())
		{
			Users.Add(user);
		}

		BindingContext = this;

	}
}