namespace Building.DataModel.Master;
public class Master : Entity
{
    public DateTime CreationTime { get; private set; }
    public required String FirstName { get; init; }
    public required String LastName { get; init; }
    public required String Email { get; init; }
    public EMasterType MasterType { get; set; } = EMasterType.General;
    public const String Phrase = "I can fix anything!";
    public readonly Int64 PhoneNumber;

    public Master(Int32 id) : base(id)
    {
        CreationTime = DateTime.Now;
    }

    public Master(Int32 id, DateTime creationTime) : base(id)
    {
        CreationTime = creationTime;
    }

    public override String ToString()
        => $"{base.ToString()} 📝 {CreationTime:yyyy.MM.dd(ddd) HH:mm} -- {FirstName} {LastName} -- from {Email} -- {MasterType.AsStr()}";

    public String GetInfo(Int32 experience)
    {
        return $"I'm a {MasterType} with {experience} of experience.";
    }

    public String GetInfo(Int32 experience, Int32 age)
    {
        return $"I'm a {age}-year old {MasterType} with {experience} of experience.";
    }
}

