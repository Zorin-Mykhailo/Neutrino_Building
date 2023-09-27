using System.Collections;

namespace Building;

public class Menu : IEnumerable<MenuItem>
{
    public String Title { get; private set; }

    public ConsoleColor Color { get; private set; }

    private Dictionary<Int32, MenuItem> _items = new();

    public Boolean ContainsKey(Int32 key) => _items.ContainsKey(key);

    public Menu(String title, ConsoleColor color = ConsoleColor.Blue)
    {
        Title = title;
        Color = color;
        _items.Add(0, new MenuItem(0, "⤴ ВИХІД"));
    }

    public void Add(MenuItem menyItem) => _items.Add(menyItem.Id, menyItem);


    public IEnumerator<MenuItem> GetEnumerator() => _items.Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _items.Values.GetEnumerator();

    private String GetMenuView()
    {
        const Int32 idLen = 3;
        String title = $" {Title} ";
        Int32 maxTitleLen = Math.Max(_items.Values.Select(e => e.Title.Length).Max(), title.Length);
        String mnu =
            $" ╭─{new String('─', idLen)}─┬─{title.PadRight(maxTitleLen, '─')}─╮\n" +
            String.Join("\n", _items.Values.OrderBy(e => e.Id).Select(e => $" │ {e.Id,idLen} │ {e.Title.PadRight(maxTitleLen)} │")) +
            $"\n ╰─{new String('─', idLen)}─┴─{new String('─', maxTitleLen)}─╯";
        return mnu;
    }

    private void ShowMenuView()
    {
        ConsoleColor prevForeColor = Console.ForegroundColor;
        //
        Console.ForegroundColor = Color;
        Console.WriteLine(GetMenuView());
        //
        Console.ForegroundColor = prevForeColor;
    }

    public Int32 ShowMenu()
    {
        ShowMenuView();
        return ExtConsole.TakeInt32("Обраний пункт меню")
            .AsNotNull()
            .BelongsToSet(_items.Keys);
    }
}