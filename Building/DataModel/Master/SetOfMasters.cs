namespace Building.DataModel.Master;
public class SetOfMasters : EntitySet<Master>
{
    public SetOfMasters(Int32 id, String name) : base(id, name)
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
                this.Where(e => e.MasterType == EMasterType.Cleaner).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 3:
                this.Where(e => e.MasterType == EMasterType.Electrician).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 4:
                this.Where(e => e.MasterType == EMasterType.Foreman).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 5:
                this.Where(e => e.MasterType == EMasterType.Plumber).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 6:
                this.Where(e => e.MasterType == EMasterType.Gardener).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 7:
                this.Where(e => e.MasterType == EMasterType.PoolMaster).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 8:
                this.Where(e => e.MasterType == EMasterType.General).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;
        }
        return base.HandleMenuChoice(menuItemNumber);
    }
}
