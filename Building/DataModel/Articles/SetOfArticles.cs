namespace Building;

public class SetOfArticles : EntitySet<Article>
{
    

    public SetOfArticles(Int32 id, String name) : base(id, name)
    {
        Menu = new("СТАТТІ", ConsoleColor.Yellow)
        {
            new (1, "Всі"),
            new (2, "Актуальні"),
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
                this.Where(e => e.Actuality == EActuality.Actual).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;
        }
        return base.HandleMenuChoice(menuItemNumber);
    }
}