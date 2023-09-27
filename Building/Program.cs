// Program.cs

using System.Text;

namespace Building;

internal class Program
{
    static void Main(String[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        SetOfArticles articles = new(1, "Статті") 
        {
            new (1) { Title = "Стаття 1", Actuality = EActuality.Deprecated },
            new (34) { Title = "Стаття 2" }
        };

#region #Support
        SetOfSupportTickets supportTickets = new (2, "Технічна підтримка")
        {
            new (1)
            {
                Title = "Не працює мишка",
                Actuality = EActuality.Actual,
                AutorEmail = "v.pupkin@mail.com",
                Text = "Перестала працювати мишка. Можливо ...", 
                State = ESupportTicketState.New                
            },
            new (2)
            {
                Title = "Збій роботи програми MyApp",
                Actuality = EActuality.Actual,
                AutorEmail = "m.romaskina@mail.com",
                Text = "Мій додаток перестав працювати в зв'язку із ...",
                State = ESupportTicketState.InProgres
            },
            new (3)
            {
                Title = "Не коректна робота API",
                Actuality = EActuality.Deprecated,
                AutorEmail = "r.ivanov@mail.com",
                Text = "Мій додаток перестав працювати в зв'язку із змінами у вашому API, що були...",
                State = ESupportTicketState.Closed
            }
        };
#endregion #Support

        MainMenu mainMenu = new()
        {
             Articles = articles,
#region #Support
             SupportTickets = supportTickets
#endregion #Support
        };

        mainMenu.ShowMenu();
    }
}