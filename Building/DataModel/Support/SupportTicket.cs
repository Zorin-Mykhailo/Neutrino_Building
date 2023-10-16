// DataModel/Support/SupportTicket.cs

#region #Support
namespace Building;

/// <summary> Звернення в тех. підтримку </summary>
public class SupportTicket : Entity
{
    /// <summary> Дата створення звернення </summary>
    public DateTime CreationTime { get; private set; }

    /// <summary> Стан звернення </summary>
    public SupportTicketState State { get; set; } = SupportTicketState.New;

    /// <summary> Стисла назва звернення </summary>
    public required string Title { get; init; }

    /// <summary> Email автора </summary>
    public required string AutorEmail { get; init; }

    /// <summary> Текст звернення </summary>
    public required string Text { get; init; }

    /// <summary> Конструктор, що наслідуєься від базового </summary>
    /// <param name="id"></param>
    public SupportTicket(int id, DateTime creationTime) : base(id)
        => CreationTime = creationTime;

    /// <summary> Перевантажений конструктор в якому автоматично заповнюється дата створення </summary>
    /// <param name="id"></param>
    public SupportTicket(int id) : base(id)
        => CreationTime = DateTime.Now;

    /// <summary> Перевизначимо необхідним чином приведення до стрічки </summary>
    public override string ToString()
        => $"{base.ToString()} ⚡ {CreationTime:yyyy.MM.dd(ddd) HH:mm} -- {Title} -- from {AutorEmail} -- {State.AsSignAndStr()}";
}

#endregion #Support