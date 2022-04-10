using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Material.Dialog;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoomReservationSystem;

public class ViewLocator : IDataTemplate
{
    public bool SupportsRecycling => false;

    public IControl Build(object data)
    {
        var name = data.GetType().FullName.Replace("Page", "PageVM");
        var type = Type.GetType(name);

        if (type != null)
            return (Control)App.Services.GetRequiredService(type);
        else
            return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object data)
    {
        return data is ViewModelBase;
    }
}