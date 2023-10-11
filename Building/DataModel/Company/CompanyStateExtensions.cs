#region #Company
using E = Building.CompanyState;
namespace Building;
public static class CompanyStateExtensions
{
    public static string AsStr(this E enumValue) => _namesOfEnum[enumValue];

    private static readonly Dictionary<E, string> _namesOfEnum;

    static CompanyStateExtensions()
    {
        _namesOfEnum = []; // TODO розібратись або запитати викладача. Що це за ініціалізація така (її запропонувала VS) не 'new()' а '[]'. Вперше таке бачу.
        Registration(E.New, "Нова Компанія");
        Registration(E.InProgres, "Існуюча Компанія");
        Registration(E.Closed, "Закрита Компанія");
    }

    private static void Registration(E enumValue, string name) => _namesOfEnum.Add(enumValue, name);
}
#endregion #Company