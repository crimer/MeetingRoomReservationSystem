using System.Threading.Tasks;
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

    protected override Task OnInitializedAsync()
    {
        return base.OnInitializedAsync();
    }

    protected override Task OnDestroyAsync()
    {
        return base.OnDestroyAsync();
    }
}