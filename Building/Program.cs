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

        SetOfArticles articles = new("Articles") 
        {
            new (1) { Title = "Стаття 1" },
            new (34) { Title = "Стаття 2" }
        };


        Console.WriteLine(articles[34]);

        //articles.Where(e => e.Id > 1).ForEach(e => Console.WriteLine(e.Title));
    }
}