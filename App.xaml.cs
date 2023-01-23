using Hotell567.MVVM;

namespace Hotell567;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
    }
}
