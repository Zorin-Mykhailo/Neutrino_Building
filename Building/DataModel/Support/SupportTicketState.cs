// DataModel/Support/SupportTicketState.cs

#region #Support
namespace Building;

/// <summary> Стан звернення в технічну службу </summary>
public enum SupportTicketState
{
    New = 0,
    Reopened = 1,
    InProgres = 3,
    ForgotenState = 4,
    Closed = 5,
}
#endregion #Support