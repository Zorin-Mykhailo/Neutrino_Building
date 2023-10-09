namespace Building.DataModel.Master;
public static class ExtEMasterType
{
    public static string AsStr(this EMasterType enumValue) => _namesOfEnum[enumValue];

    private static readonly Dictionary<EMasterType, string> _namesOfEnum;

    static ExtEMasterType()
    {
        _namesOfEnum = new Dictionary<EMasterType, string>();
        _namesOfEnum.Add(EMasterType.Cleaner, "Прибиральник");
        _namesOfEnum.Add(EMasterType.Electrician, "Електрик");
        _namesOfEnum.Add(EMasterType.Foreman, "Прораб");
        _namesOfEnum.Add(EMasterType.Plumber, "Сантехнік");
        _namesOfEnum.Add(EMasterType.Gardener, "Садівник");
        _namesOfEnum.Add(EMasterType.PoolMaster, "Майстер Басейнів");
        _namesOfEnum.Add(EMasterType.General, "Майстер");
        _namesOfEnum.Add(EMasterType.Repairer, "Ремонтник");
    }
}
