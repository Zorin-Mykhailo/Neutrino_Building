using E = Building.PricesType;

namespace Building;
public static class ExtEType
{
    public static string AsStr(this E enumValue) => _namesOfEnum[enumValue];

    private static readonly Dictionary<E, string> _namesOfEnum = new()
    {
        { E.Instrument, "Інстурменти" },
        { E.Material, "Матеріали" },
        { E.Service, "Послуги" },
    };

}
