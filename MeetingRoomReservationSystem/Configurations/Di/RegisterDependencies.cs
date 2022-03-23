using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MeetingRoomReservationSystem.Configurations.Di;

/// <summary>
/// Регистрация зависимостей приложения
/// </summary>
public static class RegisterDependencies
{
    private static void SetConfig()
    {
#if RELEASE
            var appSettingsFile = "appsettings.Release.json";
#else
        var appSettingsFile = "appsettings.Debug.json";
#endif

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(appSettingsFile, optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configurationRoot = configuration.Build();

        configurationRoot.GetSection("Config").Bind(new AppConfig());
    }

    /// <summary>
    /// Конфигурация зависимостей приложения
    /// </summary>
    public static void ConfigureServices(this IServiceCollection services)
    {
        SetConfig();
#if DEBUG
        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddConsole();
            builder.AddDebug();
        });
#endif
    }
}