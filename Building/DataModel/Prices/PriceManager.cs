﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building;
internal class PriceManager
{
    public static DateTime SetAvailableDate(int Delay) 
    {
        DateCounter date = new DateCounter((byte)Delay);
        DateTime AvailableDate = date.Date;
        return AvailableDate;
    }

    public static decimal SetPrice(decimal Price)
    {
        return Price;
    }

    public static decimal SetPrice(decimal Price, int DiscountPercentage)
    {
        decimal PriceWithDiscount = Price - (Price / 100 * DiscountPercentage);
        return PriceWithDiscount;
    }
}
