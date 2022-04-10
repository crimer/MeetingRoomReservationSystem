using System;
using System.Linq;
using MeetingRoomReservationSystem.Controls.Navigation;
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
            .AddSingleton<NavigationBarVM>()
            .AddSingleton<NavigationService>()
    .RegisterViewsAndVm<NavigationBarComponent, NavigationBarVM>()
    .RegisterViewsAndVm<AllRoomsPage, AllRoomsPageVM>()
    .RegisterViewsAndVm<CreateReservationPage, CreateReservationPageVM>();
}

public static class RegisterViews
{
    public static IServiceCollection RegisterViewsAndVm<TView, TViewModel>(this IServiceCollection serviceCollection)
        where TView : BaseUserControl<TViewModel>
        where TViewModel : BaseVM
    {
        serviceCollection.AddSingleton<TViewModel>();

        serviceCollection.AddTransient<TView>(sp =>
        {
            var view = ActivatorUtilities.CreateInstance<TView>(sp);
            if (!(view is BaseUserControl<TViewModel> viewControl))
                throw new ApplicationException();

            var vm = sp.GetRequiredService<TViewModel>();

            viewControl.DataContext = vm;
            viewControl.Initialized += (sender, args) => vm.OnInitializedAsync(sender, args);
            return view;
        });
        
        return serviceCollection;
    }
}