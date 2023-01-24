namespace Hotell567;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MVVM.RoomsPage), typeof(MVVM.RoomsPage));
    }
}
