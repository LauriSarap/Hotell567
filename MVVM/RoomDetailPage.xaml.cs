namespace Hotell567.MVVM;

public partial class RoomDetailPage : ContentPage
{
    public RoomDetailPage(RoomDetailPage viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }
}