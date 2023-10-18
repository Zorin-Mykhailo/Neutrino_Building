using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building;
internal class PriceManager
{
    public static DateTime SetAvailableDate(string delay)
    {
        DateTime AvailableDate = DateTime.Today;
        int Delay = 0;

        try
        {
            try
            {
              Delay = Convert.ToInt32(delay);
            }
            catch(System.FormatException ex)
            {
                Console.WriteLine($"Ви вказзали дані у невірному форматі!  {ex.StackTrace}");
                throw;
            }
            catch(OverflowException ex)
            {
                Console.WriteLine($"Вказане вами число є надто великим!  {ex.StackTrace}");
                throw;
            }
        }
        catch(Exception)
        {
            Console.WriteLine("Дані будуть відображені некоректно ! Перезапустіть програму, виправивши помилки!");
        }
        DateCounter date = new DateCounter(Delay);
        AvailableDate = date.Date;
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
