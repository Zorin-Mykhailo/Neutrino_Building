using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperQuery_Moroz;
public class CompanyItems
{
    public int Id { get; set; }
    public string NameOfCompany { get; set; }
    public string Description { get; set;}
    public string Owner { get; set; }

    public CompanyItems(int id, string nameOfCompany, string description, string owner)
    {
        Id = id;
        NameOfCompany = nameOfCompany;
        Description = description;
        Owner = owner;
    }
    public override bool Equals(object obj)
    {
     
        if(obj == null || GetType() != obj.GetType())
            return false;

        CompanyItems other = (CompanyItems)obj;
        return Id == other.Id && NameOfCompany == other.NameOfCompany && Description == other.Description && Owner == other.Owner;
    }

    public override int GetHashCode()
    {
        //Id doesn't repeat!!!!! it isn't mistake 
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            return hash;
        }
    }
}
