using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region #Company
namespace Building;
public class SetOfCompany : EntitySet<Company>
{
    public SetOfCompany(int id, string name) : base(id, name)
    {
        Menu = new("Компанії", ConsoleColor.DarkMagenta)
        {
            new (1, "Всі"),
            new (2, "Актуальні"),
            new (3, "Застарілі"),
            new (4, "Нові"),
            new (5, "В роботі"),
            new (6, "Закриті"),
        };
    }

    protected override EWorkWithMenu HandleMenuChoice(int menuItemNumber)
    {
        switch(menuItemNumber)
        {
            case 0:
                return EWorkWithMenu.QuitMenu;

            case 1:
                this.ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 2:
                this.Where(e => e.Actuality == EActuality.Actual).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 3:
                this.Where(e => e.Actuality == EActuality.Deprecated).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 4:
                this.Where(e => e.State == ECompanyState.New).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 5:
                this.Where(e => e.State == ECompanyState.InProgres).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 6:
                this.Where(e => e.State == ECompanyState.Closed).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;
        }
        return base.HandleMenuChoice(menuItemNumber);
    }
}
#endregion #Company