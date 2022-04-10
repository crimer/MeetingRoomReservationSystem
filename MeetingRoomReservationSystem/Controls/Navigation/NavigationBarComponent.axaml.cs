using Avalonia.Markup.Xaml;
using MeetingRoomReservationSystem.Views.Base;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoomReservationSystem.Controls.Navigation;

public partial class NavigationBarComponent : BaseUserControl<NavigationBarVM>
{
    public NavigationBarComponent()
    {
        AvaloniaXamlLoader.Load(this);
        DataContext = App.Services.GetRequiredService<NavigationBarVM>();
    }
}