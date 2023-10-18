using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building;
internal record DateCounter 
{
    public DateTime Date { get; init; }

    public DateCounter(int Delay)
    {
        DateTime Today = DateTime.Today;
        try
        {
            try
            {
                Date = Today.AddDays(Delay);

            }
            catch(ArgumentOutOfRangeException ex)
            {
                throw new Exception($"Невірне число для підрахування затримки дати виконання! {ex.StackTrace}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
