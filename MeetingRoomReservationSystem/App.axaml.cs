using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoomReservationSystem;

public class App : Application
{
    public static ServiceProvider Services { get; private set; }
    
    private Startup _startup;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        _startup = new Startup();
        Services = _startup.ConfigureServices();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = _startup.CreateMainWindow(Services);

        base.OnFrameworkInitializationCompleted();
    }
}