using Avalonia.Markup.Xaml;
using MeetingRoomReservationSystem.Views.Base;
using MeetingRoomReservationSystem.VM;

namespace MeetingRoomReservationSystem.Views.CreateReservationPage;

public partial class CreateReservationPage : BaseUserControl<CreateReservationPageVM>
{
    public CreateReservationPage()
    {
        AvaloniaXamlLoader.Load(this);
    }
}