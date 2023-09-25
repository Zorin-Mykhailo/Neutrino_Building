using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.DataModel;
public interface IEntity
{
    Int32 Id { get; init; }

    EActuality Actuality { get; init; }
}
