using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.DataModel.Articles;
public class Article : IEntity
{
    public Int32 Id { get; init; }
    
    public EActuality Actuality { get; init; } = EActuality.Actual;
}
