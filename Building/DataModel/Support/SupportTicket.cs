// DataModel/Support/SupportTicket.cs

#region #Support
namespace Building;

public class SupportTicket : Entity
{
    public DateTime CreationTime { get; private set; }

    public SupportTicketState State { get; set; } = SupportTicketState.New;

    public required string Title { get; init; }

    public required string AutorEmail { get; init; }

    public required string Text { get; init; }

    public SupportTicket(int id, DateTime creationTime) : base(id)
        => CreationTime = creationTime;

    public SupportTicket(int id) : base(id)
        => CreationTime = DateTime.Now;

    public override string ToString()
        => $"{base.ToString()} 📝 {CreationTime:yyyy.MM.dd(ddd) HH:mm} -- {Title} -- from {AutorEmail} -- {State.AsStr()}";
}

#endregion #Support