using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Prices;
internal class Instruments
{
    static readonly int DiscountPercantage = 10;

    public required int ID { get; init; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string MakerCompany { get; set; }

    public const string Group = "Інструменти";

    public void ShowPosition()
    {
        Console.WriteLine($"Найменування : {Name} \n Ціна : {Price} ");
    }

    public void ShowPosition(bool IsOnSale)
    {
        if(IsOnSale == false) { ShowPosition(); }
        else
        {
            int Discount = Price / 100 * DiscountPercantage;
            Price = Price - Discount;
            Console.WriteLine("$Найменування : {Name} \n Фірма : {MakerCompany} \n Ціна зі знижкою : {Price} ");
        }
    }
}
