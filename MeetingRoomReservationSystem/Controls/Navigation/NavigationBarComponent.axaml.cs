using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MeetingRoomReservationSystem.Views.Base;

namespace MeetingRoomReservationSystem.Controls.Navigation;

public partial class NavigationBarComponent : BaseUserControl<NavigationBarVM>
{
    public NavigationBarComponent()
    {
        AvaloniaXamlLoader.Load(this);
        
    }
}