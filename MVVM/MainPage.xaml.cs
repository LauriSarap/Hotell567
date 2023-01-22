using Windows.Networking.NetworkOperators;
using Windows.UI.ApplicationSettings;

namespace Hotell567.MVVM;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        TypewriterEffect();
    }

    private void HomeBtn_Clicked(object sender, EventArgs e)
    {
        NavigateToPage("Home");
    }

    private void LoginBtn_Clicked(object sender, EventArgs e)
    {
        NavigateToPage("LoginPage");
    }

    private void NavigateToPage(string page)
    {
        switch (page)
        {
            case "Home":
                var homePage = new NavigationPage(new MainPage());
                Application.Current.MainPage = homePage;
                break;
            case "LoginPage":
                Application.Current.MainPage = new NavigationPage(new LoginPage());
                break;
            default:
                break;
        }
    }


    private void SeeAvailableListings(object sender, EventArgs e)
    {
        DisplayAlert("See Available Listings", "This feature is not yet implemented", "OK");
    }

    private string text;
    private int lenght = 0;

    private async void TypewriterEffect()
    {
        text = WelcomeLabel.Text;
        WelcomeLabel.Text = "";

        await Task.Delay(TimeSpan.FromSeconds(1));

        for (int i = 0; i < text.Length; i++)
        {
            WelcomeLabel.Text = WelcomeLabel.Text + text.ElementAt(lenght);
            lenght++;
            await Task.Delay(TimeSpan.FromMilliseconds(100));
        }
    }
}

