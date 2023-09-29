using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    public class Company
    {
        private int _id;
        public const string DirectionInIndustry = "Construction and restoration";
        private string _description;
        public readonly string DateOfCreate = DateTime.Now.ToShortDateString();
        private string _owner;
        public required string NameOfCompany { get; init; }
        public string Description
        {
            get {return _description;}
            set {_description = value;}
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
        public string GetTechInfo()
        {
            return $"ID:{Id}, {NameOfCompany}\n{Description}\n{DateOfCreate}";
        }
        public string GetTechInfo(string customeDescription)
        {
            return $"ID:{Id}, {NameOfCompany}\n{customeDescription}\n{DateOfCreate}";
        }

    }
}
