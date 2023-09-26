using Building.DataModel;
using Building.DataModel.Articles;
using Building.Extensions;
using System.Linq;
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
            new (1) { Title = "Стаття 1" },
            new (34) { Title = "Стаття 2" }
        };

        MainMenu mainMenu = new()
        {
             Articles = articles,
        };

        Console.WriteLine(mainMenu.GetMenuItems());
        mainMenu.Articles.ForEach(e => Console.WriteLine(e));


        //articles.Where(e => e.Id > 1).ForEach(e => Console.WriteLine(e.Title));
    }
}