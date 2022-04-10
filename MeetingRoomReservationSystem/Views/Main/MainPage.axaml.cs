using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MeetingRoomReservationSystem.Views.Main;

public partial class MainPage : Window
{
    public MainPage()
    {
        AvaloniaXamlLoader.Load(this);
#if DEBUG
        this.AttachDevTools();
#endif
    }
}