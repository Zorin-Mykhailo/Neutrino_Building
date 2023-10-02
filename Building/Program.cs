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


        #region #Prices
        SetOfPrices prices = new (3, "Ціни")
        {
            new (1)
            {
               Name = "Мішок цементу",
               ItemPrice = 168.25m ,
               Type = EType.Material
            },
            new (2)
            {
               Name = "Мішок штукатурки",
               ItemPrice = 126.0m ,
               Type = EType.Material
            },
            new (3)
            {
               Name = "Мішок шпаклівки",
               ItemPrice = 450.0m ,
               Type = EType.Material
            },
            new (4)
            {
               Name = "Ларезний рівень",
               ItemPrice = 2250.0m ,
               Type = EType.Instrument
            },
            new (5)
            {
               Name = "Перфоратор",
               ItemPrice = 3100.0m ,
               Type = EType.Instrument
            },
            new (6)
            {
               Name = "Набір викруток",
               ItemPrice = 899.0m ,
               Type = EType.Instrument
            },
            new (7)
            {
               Name = "Ремонт даху будівлі, метр квадратний",
               ItemPrice = 880.0m ,
               Type = EType.Service
            },
            new (8)
            {
               Name = "Автоперевезення, ціна за 100 кг",
               ItemPrice = 1100.0m ,
               Type = EType.Service
            },
            new (9)
            {
               Name = "Консультація електрика",
               ItemPrice = 500.0m ,
               Type = EType.Service
            }
        };
#endregion #Prices


        MainMenu mainMenu = new()
        {
             Articles = articles,
#region #Support
             SupportTickets = supportTickets,
#endregion #Support

#region #Prices
             Prices = prices,
#endregion #Prices
        };

        mainMenu.ShowMenu();
    }
}