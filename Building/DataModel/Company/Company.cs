using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region #Company
namespace Building;
public class Company : Entity
{
    private int _id;
    public const string DirectionInIndustry = "Construction and restoration";
    private string _description;
    public readonly string DateOfCreate = DateTime.Now.ToShortDateString();
    private string _owner;
    public ECompanyState State { get; set; } = ECompanyState.New;
    public required string NameOfCompany { get; init; }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Owner
    {
        get { return _owner; }
        set { _owner = value; }
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