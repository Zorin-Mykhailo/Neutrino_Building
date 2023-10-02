namespace Building.DataModel.Master;
public static class ExtEMasterType
{
    public static String AsStr(this EMasterType enumValue) => _namesOfEnum[enumValue];

    private static readonly Dictionary<EMasterType, String> _namesOfEnum;

    static ExtEMasterType()
    {
        _namesOfEnum = new Dictionary<EMasterType, String>();
        _namesOfEnum.Add(EMasterType.Cleaner, "Прибиральник");
        _namesOfEnum.Add(EMasterType.Electrician, "Електрик");
        _namesOfEnum.Add(EMasterType.Foreman, "Прораб");
        _namesOfEnum.Add(EMasterType.Plumber, "Сантехнік");
        _namesOfEnum.Add(EMasterType.Gardener, "Садівник");
        _namesOfEnum.Add(EMasterType.PoolMaster, "Майстер Басейнів");
        _namesOfEnum.Add(EMasterType.General, "Майстер");
    }
}
