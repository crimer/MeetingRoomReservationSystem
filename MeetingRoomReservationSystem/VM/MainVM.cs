namespace MeetingRoomReservationSystem.VM;

public class MainVM : BaseVM
{
    public override string Title => "Главная";

    public MainVM()
    {
        Navigation.NavigateTo(new AllRoomsPageVM());
    }
}