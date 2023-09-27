// DataModel/Support/ExtESupportTicketState.cs

#region #Support
using E = Building.ESupportTicketState;
namespace Building;

public static class ExtESupportTicketState
{
    public static String AsStr(this E enumValue) => _namesOfEnum[enumValue];

    private static readonly Dictionary<E, String> _namesOfEnum;
    
    static ExtESupportTicketState()
    {
        _namesOfEnum = new Dictionary<E, String>();
        Registration(E.New, "Нове звернення");
        Registration(E.InProgres, "В роботі");
        Registration(E.Closed, "Завершено");
    }

    private static void Registration(E enumValue, String name) => _namesOfEnum.Add(enumValue, name);
}
#endregion #Support