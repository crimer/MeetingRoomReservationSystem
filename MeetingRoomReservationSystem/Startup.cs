using Avalonia.Controls;
using MeetingRoomReservationSystem.DependencyInjection;
using MeetingRoomReservationSystem.Views.Main;
using MeetingRoomReservationSystem.VM;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoomReservationSystem;

public class Startup
{
    public ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.RegisterDependencyInjection();
        return services.BuildServiceProvider();
    }

    public Window CreateMainWindow(ServiceProvider serviceProvider)
    {
        var page = serviceProvider.GetRequiredService<MainPage>();
        var vm = serviceProvider.GetRequiredService<MainVM>();
        
        page.DataContext = vm;
        
        return page;
    }
}