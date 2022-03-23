using System;
using System.Linq;
using MeetingRoomReservationSystem.Services;
using MeetingRoomReservationSystem.Views.AllRoomsPage;
using MeetingRoomReservationSystem.Views.Base;
using MeetingRoomReservationSystem.Views.CreateReservationPage;
using MeetingRoomReservationSystem.Views.Main;
using MeetingRoomReservationSystem.VM;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoomReservationSystem.DependencyInjection;

public static class RegisterDependencyInjections
{
    public static IServiceCollection RegisterDependencyInjection(this IServiceCollection serviceCollection)
        => serviceCollection
            .AddSingleton<MainPage>()
            .AddSingleton<MainVM>()
            .AddSingleton<NavigationService>();
    // .RegisterViewsAndVm<AllRoomsPage, AllRoomsPageVM>()
    // .RegisterViewsAndVm<CreateReservationPage, CreateReservationPageVM>();
}

public static class RegisterViews
{
    public static IServiceCollection RegisterViewsAndVm<TView, TViewModel>(this IServiceCollection serviceCollection)
        where TView : BaseUserControl<TViewModel>
        where TViewModel : BaseVM
    {
        var vmType = typeof(TViewModel);
        var interfaces = vmType.GetInterfaces().Select(i => i.Name);
        
        if(interfaces == null || !interfaces.Any())
            throw new ApplicationException();
            
        var isSingleton = interfaces.Contains("ISingleton");
        var isTransient = interfaces.Contains("ITransient");
        var isScoped = interfaces.Contains("IScoped");
        if(isSingleton)
            serviceCollection.AddSingleton<TViewModel>();
        if(isTransient)
            serviceCollection.AddTransient<TViewModel>();
        if(isScoped)
            serviceCollection.AddScoped<TViewModel>();
        
        serviceCollection.AddTransient<TView>(sp =>
        {
            var view = ActivatorUtilities.CreateInstance<TView>(sp);
            if (!(view is BaseUserControl<TViewModel> viewControl))
                throw new ApplicationException();

            var vm = sp.GetRequiredService<TViewModel>();

            viewControl.DataContext = vm;
            return view;
            // viewControl.Initialized += (sender, args) => vm.
        });
        
        return serviceCollection;
    }
}