namespace Building.DataModel.Master;
public static class MasterTypeExtension
{
    public static string AsStr(this MasterType enumValue) => _namesOfEnum[enumValue];

    private static readonly Dictionary<MasterType, string> _namesOfEnum;

    static MasterTypeExtension()
    {
        _namesOfEnum = [];
        _namesOfEnum.Add(MasterType.Cleaner, "Прибиральник");
        _namesOfEnum.Add(MasterType.Electrician, "Електрик");
        _namesOfEnum.Add(MasterType.Foreman, "Прораб");
        _namesOfEnum.Add(MasterType.Plumber, "Сантехнік");
        _namesOfEnum.Add(MasterType.Gardener, "Садівник");
        _namesOfEnum.Add(MasterType.PoolMaster, "Майстер Басейнів");
        _namesOfEnum.Add(MasterType.General, "Майстер");
        _namesOfEnum.Add(MasterType.Repairer, "Ремонтник");
    }
}
