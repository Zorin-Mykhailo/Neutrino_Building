using E = Building.PricesType;

namespace Building;
public static class ExtEType
{
    public static string AsStr(this E enumValue) => _namesOfEnum[enumValue];

    private static readonly Dictionary<E, string> _namesOfEnum;

    static ExtEType()
    {
        _namesOfEnum = new Dictionary<E, string>();
        Registration(E.Instrument, "Інстурменти");
        Registration(E.Material, "Матеріали");
        Registration(E.Service, "Послуги");
    }

    private static void Registration(E enumValue, string name) => _namesOfEnum.Add(enumValue, name);






}
