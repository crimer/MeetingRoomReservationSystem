using System.Windows.Input;
using MeetingRoomReservationSystem.Commands;
using MeetingRoomReservationSystem.Services;
using MeetingRoomReservationSystem.VM;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoomReservationSystem.Controls.Navigation;

public class NavigationBarVM : BaseVM
{
    private readonly NavigationService _navigationService;
    public ICommand NavigateToCommand { get; }
    
    public NavigationBarVM(NavigationService navigationService)
    {
        _navigationService = navigationService;
        NavigateToCommand = new ActionCommand(NavigateTo);
    }

    private void NavigateTo()
    {
        _navigationService.NavigateTo(new CreateReservationPageVM());
    }
}