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
        new (1, "Послуги"),
        new (2, "Матеріали"),
        new (3, "Інструменти"),
    };

        var menu = Enum.GetValues(typeof(ItemType));
    }

    protected override WorkWithMenu HandleMenuChoice(Int32 menuItemNumber)
    {
        if(menuItemNumber == 0) { return WorkWithMenu.QuitMenu; }

        this.Where(e => (int)e.Type == menuItemNumber).ForEach(e => Console.WriteLine(e));
        return WorkWithMenu.ContinueWork;

    }
}
















