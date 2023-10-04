using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building;
public class Price : Entity
{
    static readonly int DiscountPercantage = 10;
    public required string Name { get; set; }
    public required decimal ItemPrice { get; set; }
    public DateTime Available { get; private set; }
    public EType Type { get; set; }

    public Price(Int32 id) : base(id)
    { 
        Available = DateTime.Today;
        Available = Available.AddDays(2);
        ItemPrice = ItemPrice - (ItemPrice / 100 *  DiscountPercantage);
    }

    public override String ToString()
        => $"{base.ToString()} 📝{Name} \n Ціна зі знижкою (10%) : {ItemPrice} грн \n Можна замовити : {Available:yyyy.MM.dd(ddd)} ";

}
