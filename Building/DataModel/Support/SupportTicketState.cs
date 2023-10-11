// DataModel/Support/SupportTicketState.cs

#region #Support
namespace Building;

/// <summary> Стан звернення в технічну службу </summary>
public enum SupportTicketState
{
    /// <summary> Нове </summary>
    New,
    /// <summary> В роботі </summary>
    InProgres,
    /// <summary> Завершене </summary>
    Closed
}
#endregion #Support