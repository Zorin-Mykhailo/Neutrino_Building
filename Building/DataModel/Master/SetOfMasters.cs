namespace Building.DataModel.Master;
public class SetOfMasters : EntitySet<Master>
{
    public SetOfMasters(int id, string name) : base(id, name)
    {
        Menu = new("Список майстрів", ConsoleColor.Cyan)
        {
            new (1, "Всі"),
            new (2, "Прибиральники"),
            new (3, "Електрики"),
            new (4, "Прораби"),
            new (5, "Сантехніки"),
            new (6, "Садівники"),
            new (7, "Майстри Басейнів"),
            new (8, "Майстри"),
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
                this.Where(e => e.MasterType == MasterType.Cleaner).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 3:
                this.Where(e => e.MasterType == MasterType.Electrician).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 4:
                this.Where(e => e.MasterType == MasterType.Foreman).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 5:
                this.Where(e => e.MasterType == MasterType.Plumber).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 6:
                this.Where(e => e.MasterType == MasterType.Gardener).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 7:
                this.Where(e => e.MasterType == MasterType.PoolMaster).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;

            case 8:
                this.Where(e => e.MasterType == MasterType.General).ForEach(e => Console.WriteLine(e));
                return WorkWithMenu.ContinueWork;
        }
        return base.HandleMenuChoice(menuItemNumber);
    }
}
