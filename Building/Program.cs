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

        MainMenu mainMenu = new()
        {
             Articles = articles,
        };

        mainMenu.ShowMenu();
    }
}