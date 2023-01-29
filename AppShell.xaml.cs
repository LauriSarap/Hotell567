namespace Hotell567;

public partial class AppShell : Shell
{
    private static AppShell appShellSingleton;
    
    public AppShell()
    {
        InitializeComponent();
        appShellSingleton = this;

        Routing.RegisterRoute(nameof(MVVM.RoomsPage), typeof(MVVM.RoomsPage));
    }
    public static AppShell GetSingleton
    {
        get
        {
            return appShellSingleton;
        }
    }

    public void ShowPagesAfterLogin()
    {
        adminTab.IsVisible = true;
        accountTab.IsVisible = true;
    }

    public void HidePagesAfterLogout()
    {
        adminTab.IsVisible = false;
        accountTab.IsVisible = false;
    }
}
