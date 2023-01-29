using CommunityToolkit.Mvvm.ComponentModel;

namespace Hotell567.Data
{
    [QueryProperty(nameof(Room), "Room")]
    public partial class RoomDetailViewModel : BaseViewModel
    {
        public RoomDetailViewModel()
        {

        }

        [ObservableProperty]
        public Room detailRoom;
    }
}
