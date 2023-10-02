using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region #Company
namespace Building;
public class Company : Entity
{
    private Int32 _id;
    public const String DirectionInIndustry = "Construction and restoration";
    private String _description;
    public readonly String DateOfCreate = DateTime.Now.ToShortDateString();
    private String _owner;
    public ECompanyState State { get; set; } = ECompanyState.New;
    public required String NameOfCompany { get; init; }
    public String Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public Int32 Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public String Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }
    public Company(Int32 id) : base(id)
    {
        Description = "We are greate building company";
    }
    public Company(Int32 id, String description) : base(id)
    {
        Description = description;
    }
    public String GetTechInfo()
    {
        return $"ID:{Id}, {NameOfCompany}\n{Description}\n{DateOfCreate}";
    }
    public String GetTechInfo(String customDescription)
    {
        return $"ID:{Id}, {NameOfCompany}\n{customDescription}\n{DateOfCreate}";
    }
    public override String ToString()
        => $"{base.ToString()} 📝 {DateOfCreate:yyyy.MM.dd(ddd) HH:mm} -- {NameOfCompany} -- from {Owner} -- {State.AsStr()}";
}
#endregion #Company