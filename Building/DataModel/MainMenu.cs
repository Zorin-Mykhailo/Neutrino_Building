// DataModel/MainMenu.cs

using Building.DataModel.Master;

namespace Building;

public class MainMenu
{
    private Menu Menu { get; set; }

    public required SetOfArticles Articles { get; init; }

#region #Support
    /// <summary> Звернення в тех. підтримку </summary>
    public required SetOfSupportTickets SupportTickets { get; init; }
#endregion #Support

#region #Prices
    public required SetOfPrices Prices { get; init; }
    #endregion #Prices

    public required SetOfMasters Masters { get; init; }

    public MainMenu()
    {
        Menu = new("ГОЛОВНЕ МЕНЮ", ConsoleColor.Green)
        {
            // 0 - Вихід додається автоматично
            new (1, "Статті"),
            
#region #Support
            new (2, "Технічна підтримка"),
#endregion #Support

#region #Prices
            new (3, "Ціни"),
#endregion #Prices

            new (4, "Майстри"),
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
            #region #Support
            case 2:
                SupportTickets.ShowMenu();
                return EWorkWithMenu.ContinueWork;
            #endregion #Support
            #region #Prices
            case 3:
                Prices.ShowMenu();
                return EWorkWithMenu.ContinueWork;
            #endregion #Prices
            case 4:
                Masters.ShowMenu();
                return EWorkWithMenu.ContinueWork;

        }
        return EWorkWithMenu.QuitMenu;
    }
}