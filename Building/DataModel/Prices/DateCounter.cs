using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building;
internal record DateCounter 
{
    public DateTime Date { get; init; }

    public DateCounter ()
    {
        DateTime Today = DateTime.Now;
        Date = Today.AddDays(2);   
    }
}
