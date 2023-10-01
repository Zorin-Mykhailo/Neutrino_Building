using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Prices;
internal class Services
{
    public required int ID { get; init; }
    public string ServiceType { get; set; }
    public int Price { get; set; }

    public DateTime PossibleDate = new DateTime();

    public const string Group = "Послуги";


    public Services()
    {
        PossibleDate = DateTime.Today;
        PossibleDate = PossibleDate.AddDays(2);
    }

    public void ShowServise()
    {
        Console.WriteLine($"Вид послуги : {ServiceType} \n Ціна : {Price} \n Можливо зробити : {PossibleDate}");
    }
}
