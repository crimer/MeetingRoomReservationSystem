using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia;
using MeetingRoomReservationSystem.Configurations.Di;
using Microsoft.Extensions.DependencyInjection;
using Projektanker.Icons.Avalonia;
using Projektanker.Icons.Avalonia.FontAwesome;

namespace MeetingRoomReservationSystem;

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
        TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;

        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder
            .Configure<App>()
            .AfterSetup(AfterSetupCallback)
            .UsePlatformDetect()
            .LogToTrace();

    private static void AfterSetupCallback(AppBuilder obj)
    {
        IconProvider.Register<FontAwesomeIconProvider>();
    }

    private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        => LogAppException(e.ExceptionObject.ToString());

    private static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        => LogAppException(e.Exception.ToString());

    private static void LogAppException(string errorText)
    {
        Console.WriteLine(errorText);
        Console.Error.WriteLine();

        var file = Path.Combine("fatal.log");
        File.AppendAllText(file, errorText);
        File.AppendAllText(file, Environment.NewLine);
    }
}