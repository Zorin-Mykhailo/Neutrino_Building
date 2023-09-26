namespace Building;

public class MainMenu
{
    private Menu Menu { get; set; }

    public required SetOfArticles Articles { get; init; }

    // 


    public MainMenu()
    {
        Menu = new("ГОЛОВНЕ МЕНЮ", ConsoleColor.Green)
        {
            // 0 - Вихід додається автоматично
            new (1, "Статті"),
            // new (2, "Ваш пункт меню"), // Додайте ваш пункт меню
        };

    }

    public void ShowMenu()
    {
        EWorkWithMenu workWithMenu = EWorkWithMenu.QuitMenu;
        do
        {
            try
            {
                workWithMenu = HandleMenuChoice(Menu.ShowMenu());
            }
            catch(Exception ex)
            {
                ExtConsole.ShowError(ex.Message);
            }

        } while(workWithMenu == EWorkWithMenu.ContinueWork);
    }

    public EWorkWithMenu HandleMenuChoice(Int32 menuItemNumber)
    {
        switch(menuItemNumber)
        {
            case 0:
                return EWorkWithMenu.QuitMenu;
            case 1:
                Articles.ShowMenu();
                return EWorkWithMenu.ContinueWork;

        }
        return EWorkWithMenu.QuitMenu;
    }
}