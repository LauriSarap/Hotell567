using Hotell567.Data;

namespace Hotell567.MVVM;

public partial class RoomDetailPage : ContentPage
{
    public RoomDetailPage(RoomDetailViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }
}