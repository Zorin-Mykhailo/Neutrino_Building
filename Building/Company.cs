using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    public class Company
    {
        // Назва команії, направлення у галузі (воно не змінюється), опис
        private string _nameOfCompany;
        private const string _directionInIndustry = "Construction and restoration";
        readonly string _description;

        public required string nameOfCompany
        {
            get
            {
                return _nameOfCompany;
            }
            set
            {
                _nameOfCompany = value;
            }
        }

    }
}
