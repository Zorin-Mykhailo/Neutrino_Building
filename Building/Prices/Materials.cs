using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Prices;
internal class Materials
{

    static readonly int DiscountPercantage = 7;

    public required int ID { get; init; }
    public string Name { get; set; }
    public int Price { get; set; }

    public const string Group = "Матеріали";


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
            Console.WriteLine("$Найменування : {Name} \\n Оптова ціна : {Price} ");
        }
    }
}
