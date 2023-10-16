// DataModel/Support/SupportTicketStateExtensions.cs

#region #Support
using System.Text;
using E = Building.SupportTicketState;
namespace Building;

public static class SupportTicketStateExtensions
{
    public static string AsStr(this E enumValue) => _namesOfEnum[enumValue];

    public static string AsSign(this E enumValue) => _signsOfEnum[enumValue];

    public static string AsSignAndStr(this E enumValue)
    {
        StringBuilder sb = new (AsSign(enumValue));
        if(sb.Length > 0) _ =sb.Append(' ');
        _ = sb.Append(AsStr(enumValue));
        return sb.ToString();
    }

    private readonly static Dictionary<E, string> _namesOfEnum;
    
    private readonly static Dictionary<E, string> _signsOfEnum;

    static SupportTicketStateExtensions()
    {
        _namesOfEnum = [];
        _signsOfEnum = [];
        //
        Registration(E.New, "Нове звернення", "✨");
        Registration(E.InProgres, "В роботі", "⏳");
        Registration(E.Closed, "Завершено", "✔️");
    }

    private static void Registration(E enumValue, string name, string icon)
    {        
        _namesOfEnum.Add(enumValue, name);
        _signsOfEnum.Add(enumValue, icon);
    }
}
#endregion #Support