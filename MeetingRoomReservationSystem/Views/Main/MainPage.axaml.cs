using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Templates;
using MeetingRoomReservationSystem.VM;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoomReservationSystem.Views.Main;

public partial class MainPage : Window
{
    public MainPage()
    {
        AvaloniaXamlLoader.Load(this);
#if DEBUG
        this.AttachDevTools();
#endif

        // var t = this.FindControl<ContentControl>("Control");
        // t.DataTemplates.Add(
        //     new DataTemplate()
        //     {
        //         DataType = typeof(CreateReservationPageVM),
        //         Content = App.Services.GetRequiredService<CreateReservationPage.CreateReservationPage>()
        //     }
        //     );
    }
}