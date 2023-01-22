namespace Hotell567.MVVM;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        TypewriterEffect();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("LoginPage");
        //Shell.Current.FlyoutIsPresented = true;
    }

    string text;
    int lenght = 0;

    private async void TypewriterEffect()
    {
        text = lblText.Text;
        lblText.Text = "";

        await Task.Delay(TimeSpan.FromSeconds(1));

        for (int i = 0; i < text.Length; i++)
        {
            lblText.Text = lblText.Text + text.ElementAt(lenght);
            lenght++;
            await Task.Delay(TimeSpan.FromMilliseconds(100));
        }
    }
}

