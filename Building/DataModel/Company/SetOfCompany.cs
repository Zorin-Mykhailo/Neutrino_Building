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

    protected override WorkWithMenu HandleMenuChoice(int menuItemNumber)
    {
        switch(menuItemNumber)
        {
            case 0:
                return WorkWithMenu.QuitMenu;

            case 1:
                this.ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 2:
                this.Where(e => e.Actuality == Actuality.Actual).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 3:
                this.Where(e => e.Actuality == Actuality.Deprecated).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 4:
                this.Where(e => e.State == CompanyState.New).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 5:
                this.Where(e => e.State == CompanyState.InProgres).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 6:
                this.Where(e => e.State == CompanyState.Closed).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;
        }
        return base.HandleMenuChoice(menuItemNumber);
    }
}
#endregion #Company