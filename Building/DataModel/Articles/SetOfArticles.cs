using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.DataModel.Articles;
public class SetOfArticles : IEntitySet<Article>
{
    public Article AddItem(Article item) => throw new NotImplementedException();
    public Article GetItem(Int32 id) => throw new NotImplementedException();
    public IEnumerable<Article> GetItems(EActuality? eActuality) => throw new NotImplementedException();
    public Int32 GetNextFreeId() => throw new NotImplementedException();
    public void RemoveItem(Article item) => throw new NotImplementedException();
}