// DataModel/Support/SetOfSupportTickets.cs

#region #Support
namespace Building;

public class SetOfSupportTickets : EntitySet<SupportTicket>
{
    /// <summary> В конструкторі опишемо пункти меню, що будуть використовуватись в розділі Тех. підтримка </summary>
    /// <param name="id"> Id </param>
    /// <param name="name"> Назва (набору звернень) </param>
    public SetOfSupportTickets(Int32 id, String name) : base(id, name)
    {
        // Для вашого меню можна задати власний колір, напририклад червоний
        Menu = new("Звернення в тех. підтримку", ConsoleColor.Red)
        {
            new (1, "Всі"),
            new (2, "Актуальні"),
            new (3, "Застарілі"),
            new (4, "Нові"),
            new (5, "В роботі"),
            new (6, "Завершені"),
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

            case 3:
                this.Where(e => e.Actuality == EActuality.Deprecated).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 4:
                this.Where(e => e.State == ESupportTicketState.New).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 5:
                this.Where(e => e.State == ESupportTicketState.InProgres).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;

            case 6:
                this.Where(e => e.State == ESupportTicketState.Closed).ForEach(e => Console.WriteLine(e));
                return EWorkWithMenu.ContinueWork;
        }
        return base.HandleMenuChoice(menuItemNumber);
    }
}
#endregion #Support