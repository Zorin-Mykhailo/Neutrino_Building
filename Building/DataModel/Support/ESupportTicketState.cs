// DataModel/Support/ESupportTicketState.cs

#region #Support
namespace Building;

/// <summary> Стан звернення в технічну службу </summary>
public enum ESupportTicketState
{
    /// <summary> Нове </summary>
    New,
    /// <summary> В роботі </summary>
    InProgres,
    /// <summary> Завершене </summary>
    Closed
}
#endregion #Support