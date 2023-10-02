using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building;
public class SetOfPrices : EntitySet<Price>
{

    public SetOfPrices(Int32 id, String name) : base(id, name)
    {
        Menu = new("Перелік цін на :", ConsoleColor.Red)
        {
            new (1, "Матеріали"),
            new (2, "Інструменти"),
            new (3, "Послуги"),
        };
    }

    protected override EWorkWithMenu HandleMenuChoice(Int32 menuItemNumber)
    {
        switch(menuItemNumber)
        {
            case 0:
                return EWorkWithMenu.QuitMenu;

            case 1:
                this.ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 2:
                this.Where(e => e.Type == EType.Material).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 3:
                this.Where(e => e.Type == EType.Instrument).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 4:
                this.Where(e => e.Type == EType.Service).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork; 
        }
        return base.HandleMenuChoice(menuItemNumber);
    }















}
