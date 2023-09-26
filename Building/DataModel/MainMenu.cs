using Building.DataModel.Articles;


namespace Building.DataModel;
public class MainMenu
{
    // Articles entity set (M. Zorin)
    public required SetOfArticles Articles { get; init; }

    public MainMenu() { }



    public String GetMenuItems()
    {
        return "--- МЕНЮ -----\n"
            + Articles.ToString()
            // TODO add your entity set
            ;
    }

}
