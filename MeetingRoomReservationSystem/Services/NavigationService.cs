using System.Collections.Generic;
using MeetingRoomReservationSystem.Helpers;
using MeetingRoomReservationSystem.VM;

namespace MeetingRoomReservationSystem.Services;

public class NavigationService : Bindable
{
    private Stack<BaseVM> _navigationStack;
    public BaseVM CurrentViewModel { get => Get<BaseVM>(); set => Set(value); }

    public NavigationService()
    {
        _navigationStack = new Stack<BaseVM>();
    }

    public void NavigateBack()
    {
        if(_navigationStack.Count <= 1)
            return;
        
        _navigationStack.Pop();
        
        CurrentViewModel = _navigationStack.Peek();
    }

    public void NavigateTo(BaseVM baseVm)
    {
        _navigationStack.Push(baseVm);
        CurrentViewModel = baseVm;
    }
}