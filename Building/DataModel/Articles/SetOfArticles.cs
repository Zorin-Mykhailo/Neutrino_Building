namespace Building;

public class SetOfArticles : EntitySet<Article>
{
    

    public SetOfArticles(int id, string name) : base(id, name)
    {
        Menu = new("СТАТТІ", ConsoleColor.Yellow)
        {
            new (1, "Всі"),
            new (2, "Актуальні"),
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
        }
        return base.HandleMenuChoice(menuItemNumber);
    }
}