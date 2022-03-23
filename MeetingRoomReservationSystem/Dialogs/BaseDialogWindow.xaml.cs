using Avalonia.Controls;

namespace MeetingRoomReservationSystem.Dialogs;

public partial class BaseDialogWindow : Window
{
    public DialogResult ResultStatus { get; set; }
    public object ResultValue { get; set; }

    public BaseDialogWindow()
    {
        InitializeComponent();
    }
}