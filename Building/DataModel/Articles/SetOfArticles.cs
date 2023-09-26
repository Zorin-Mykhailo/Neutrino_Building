namespace Building.DataModel.Articles;

public class SetOfArticles : EntitySet<Article>
{
    public SetOfArticles(Int32 id, String name) : base(id, name)
    {
    }
}