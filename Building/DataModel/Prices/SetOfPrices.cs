using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building;
public class SetOfPrices : EntitySet<Price>
{

    public SetOfPrices(int id, string name) : base(id, name)
    {
        Menu = new("Перелік цін на :", ConsoleColor.Red)
        {
            new (1, "Матеріали"),
            new (2, "Інструменти"),
            new (3, "Послуги"),
        };
    }

    protected override WorkWithMenu HandleMenuChoice(int menuItemNumber)
    {
        switch(menuItemNumber)
        {
            case 0:
                return WorkWithMenu.QuitMenu;

            case 1:
                this.Where(e => e.Type == PricesType.Material).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 2:
                this.Where(e => e.Type == PricesType.Instrument).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 3:
                this.Where(e => e.Type == PricesType.Service).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork; 
        }
        return base.HandleMenuChoice(menuItemNumber);
    }















}
