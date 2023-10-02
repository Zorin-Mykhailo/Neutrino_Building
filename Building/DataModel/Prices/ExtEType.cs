using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = Building.EType;

namespace Building;
public static class ExtEType
{
    public static String AsStr(this E enumValue) => _namesOfEnum[enumValue];

    private static readonly Dictionary<E, String> _namesOfEnum;

    static ExtEType()
    {
        _namesOfEnum = new Dictionary<E, String>();
        Registration(E.Instrument, "Інстурменти");
        Registration(E.Material, "Матеріали");
        Registration(E.Service, "Послуги");
    }

    private static void Registration(E enumValue, String name) => _namesOfEnum.Add(enumValue, name);






}
