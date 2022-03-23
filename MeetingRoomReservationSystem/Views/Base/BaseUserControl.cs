using System.Threading.Tasks;
using Avalonia.Controls;
using MeetingRoomReservationSystem.VM;

namespace MeetingRoomReservationSystem.Views.Base;

public class BaseUserControl<TViewModel> : UserControl where TViewModel : BaseVM
{
    // public TViewModel? ViewModel => this.DataContext as  TViewModel;
    
    protected virtual Task OnInitializedAsync()
    {
        return Task.CompletedTask;
    }
    
    protected virtual Task OnDestroyAsync()
    {
        return Task.CompletedTask;
    }
}