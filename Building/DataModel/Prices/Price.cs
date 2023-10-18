using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building;
public class Price : Entity
{
    const int DiscountPercentage = 11;
    public required string Name { get; set; }

    public readonly decimal ItemPrice;

    public DateTime AvailableDate;
    public PricesType Type { get; set; }

    public Price(int id, decimal Price, bool IsOnDiscount, int Delay) : base(id)

    {
        AvailableDate = PriceManager.SetAvailableDate(Delay);

        if(IsOnDiscount == true)
        {
            ItemPrice = PriceManager.SetPrice(Price, DiscountPercentage);
        }
        else
        {
            ItemPrice = PriceManager.SetPrice(Price);
        }
    }

    public override string ToString()
        => $"{base.ToString()} 📝{Name} \n Ціна : {ItemPrice} грн \n Можна замовити : {AvailableDate:yyyy.MM.dd(ddd)} ";

}
