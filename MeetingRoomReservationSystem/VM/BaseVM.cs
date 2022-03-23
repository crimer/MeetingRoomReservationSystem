using System.Threading.Tasks;
using System.Windows.Input;
using MeetingRoomReservationSystem.Commands;
using MeetingRoomReservationSystem.Helpers;
using MeetingRoomReservationSystem.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoomReservationSystem.VM;

public class BaseVM : Bindable
{
    private readonly NavigationService _navigationService;
    public NavigationService Navigation => _navigationService;
    public virtual string Title { get; }
    public ICommand NavigateToCommand { get; }
    public ICommand NavigateBackCommand { get; }

    protected BaseVM()
    {
        _navigationService = App.Services.GetRequiredService<NavigationService>();
        NavigateToCommand = new ActionCommand(NavigateTo);
        NavigateBackCommand = new ActionCommand(NavigateBack);
    }

    private void NavigateBack() => _navigationService.NavigateBack();

    private void NavigateTo() => _navigationService.NavigateTo(new CreateReservationPageVM());

    
    protected virtual Task OnInitializedAsync()
    {
        return Task.CompletedTask;
    }
    
    protected virtual Task OnDestroyAsync()
    {
        return Task.CompletedTask;
    }
}