// DataModel/Support/SupportTicketStateExtensions.cs

#region #Support
using E = Building.SupportTicketState;
namespace Building;

public static class SupportTicketStateExtensions
{
    public static string AsStr(this E enumValue) => _namesOfEnum[enumValue];

    private static readonly Dictionary<E, string> _namesOfEnum;
    
    static SupportTicketStateExtensions()
    {
        _namesOfEnum = new Dictionary<E, String>();
        Registration(E.New, "Нове звернення");
        Registration(E.InProgres, "В роботі");
        Registration(E.Closed, "Завершено");
    }

    private static void Registration(E enumValue, string name) => _namesOfEnum.Add(enumValue, name);
}
#endregion #Support