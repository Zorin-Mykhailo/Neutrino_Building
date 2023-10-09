using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region #Company
using E = Building.ECompanyState;
namespace Building;
public static class ExtECompanyState
{
    public static string AsStr(this E enumValue) => _namesOfEnum[enumValue];

    private static readonly Dictionary<E, string> _namesOfEnum;

    static ExtECompanyState()
    {
        _namesOfEnum = new Dictionary<E, string>();
        Registration(E.New, "Нова Компанія");
        Registration(E.InProgres, "Існуюча Компанія");
        Registration(E.Closed, "Закрита Компанія");
    }

    private static void Registration(E enumValue, string name) => _namesOfEnum.Add(enumValue, name);
}
#endregion #Company