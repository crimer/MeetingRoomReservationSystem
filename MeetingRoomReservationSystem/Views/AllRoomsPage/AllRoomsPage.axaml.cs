using Avalonia.Markup.Xaml;
using MeetingRoomReservationSystem.Views.Base;
using MeetingRoomReservationSystem.VM;

namespace MeetingRoomReservationSystem.Views.AllRoomsPage;

public partial class AllRoomsPage : BaseUserControl<AllRoomsPageVM>
{
    public AllRoomsPage()
    {
        AvaloniaXamlLoader.Load(this);
    }
}