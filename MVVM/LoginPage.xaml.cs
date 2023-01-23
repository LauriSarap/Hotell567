using System.Reflection;
using System.IO;

namespace Hotell567.MVVM;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

		// TODO only do this when app first runs
		var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
		using (Stream stream = assembly.GetManifestResourceStream("Hotell567.HotelAppDB.db"))
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				stream.CopyTo(memoryStream);

				File.WriteAllBytes("", memoryStream.ToArray()); 
			}
		}
	}
}