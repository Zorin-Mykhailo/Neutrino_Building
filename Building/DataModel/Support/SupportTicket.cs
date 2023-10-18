// DataModel/Support/SupportTicket.cs

#region #Support
namespace Building;

public class SupportTicket : Entity
{
    public DateTime CreationTime { get; private set; }

    private SupportTicketState _state = SupportTicketState.New;

    public SupportTicketState State
    {
        get => _state;
        set
        {
            try
            {
                if(value == SupportTicketState.Reopened)
                    throw new NotImplementedException("This feature not implemented");
                if(value < _state)
                    throw new ArgumentException("You can't assign previous state");
            }
            catch (NotImplementedException ex)
            {
                try
                {
                    if(_state !=  SupportTicketState.Closed && value == SupportTicketState.Reopened)
                    {
                        throw new ArgumentException("You can assign state Reopened only if previous state is Closed", ex);
                    }
                    if(value == SupportTicketState.Reopened)
                        throw;
                }
                catch
                {
                    throw;
                }
            }
            _state = value;
        }
    }

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