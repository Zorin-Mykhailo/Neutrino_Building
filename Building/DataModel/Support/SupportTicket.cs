// DataModel/Support/SupportTicket.cs

#region #Support
namespace Building;

/// <summary> Звернення в тех. підтримку </summary>
public class SupportTicket : Entity
{
    /// <summary> Дата створення звернення </summary>
    public DateTime CreationTime { get; private set; }

    /// <summary> Стан звернення </summary>
    public ESupportTicketState State { get; set; } = ESupportTicketState.New;

    /// <summary> Стисла назва звернення </summary>
    public required String Title { get; init; }

    /// <summary> Email автора </summary>
    public required String AutorEmail { get; init; }

    /// <summary> Текст звернення </summary>
    public required String Text { get; init; }

    /// <summary> Конструктор, що наслідуєься від базового </summary>
    /// <param name="id"></param>
    public SupportTicket(Int32 id, DateTime creationTime) : base(id)
        => CreationTime = creationTime;

    /// <summary> Перевантажений конструктор в якому автоматично заповнюється дата створення </summary>
    /// <param name="id"></param>
    public SupportTicket(Int32 id) : base(id)
        => CreationTime = DateTime.Now;

    /// <summary> Перевизначимо необхідним чином приведення до стрічки </summary>
    public override String ToString()
        => $"{base.ToString()} 📝 {CreationTime:yyyy.MM.dd(ddd) HH:mm} -- {Title} -- from {AutorEmail} -- {State.AsStr()}";
}

#endregion #Support