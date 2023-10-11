#region #Company
namespace Building;
public class Company : Entity
{
    public const string DirectionInIndustry = "Construction and restoration";

    private int _id;
    private string _description = string.Empty; 
    private string _owner = string.Empty;
    
    public readonly string DateOfCreate = DateTime.Now.ToShortDateString();
    
    public CompanyState State { get; set; } = CompanyState.New;
    
    public required string NameOfCompany { get; init; }
    
    public string Description
    {
        get => _description;
        set => _description = value;
    }
    public int Id // Гордій, ця властивість приховує Id базового класу Entity!
    {
        get => _id;
        set => _id = value;
    }
    public string Owner
    {
        get => _owner;
        set => _owner = value;
    }
    public Company(int id) : base(id)
    {
        Description = "We are greate building company";
    }
    public Company(int id, string description) : base(id)
    {
        Description = description;
    }
    public string GetTechInfo()
    {
        return $"ID:{Id}, {NameOfCompany}\n{Description}\n{DateOfCreate}";
    }
    public string GetTechInfo(string customDescription)
    {
        return $"ID:{Id}, {NameOfCompany}\n{customDescription}\n{DateOfCreate}";
    }
    public override string ToString()
        => $"{base.ToString()} 📝 {DateOfCreate:yyyy.MM.dd(ddd) HH:mm} -- {NameOfCompany} -- from {Owner} -- {State.AsStr()}";
}
#endregion #Company