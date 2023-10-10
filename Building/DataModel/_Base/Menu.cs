using System.Collections;

namespace Building;

public class Menu : IEnumerable<MenuItem>
{
    public string Title { get; private set; }

    public ConsoleColor Color { get; private set; }

    private Dictionary<int, MenuItem> _items = new();

    public bool ContainsKey(int key) => _items.ContainsKey(key);

    public Menu(string title, ConsoleColor color = ConsoleColor.Blue)
    {
        Title = title;
        Color = color;
        _items.Add(0, new MenuItem(0, "⤴ ВИХІД"));
    }

    public void Add(MenuItem menyItem) => _items.Add(menyItem.Id, menyItem);


    public IEnumerator<MenuItem> GetEnumerator() => _items.Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _items.Values.GetEnumerator();

    private string GetMenuView()
    {
        const int idLen = 3;
        string title = $" {Title} ";
        int maxTitleLen = Math.Max(_items.Values.Select(e => e.Title.Length).Max(), title.Length);
        string mnu =
            $" ╭─{new string('─', idLen)}─┬─{title.PadRight(maxTitleLen, '─')}─╮\n" +
            string.Join("\n", _items.Values.OrderBy(e => e.Id).Select(e => $" │ {e.Id,idLen} │ {e.Title.PadRight(maxTitleLen)} │")) +
            $"\n ╰─{new string('─', idLen)}─┴─{new string('─', maxTitleLen)}─╯";
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

    public int ShowMenu()
    {
        ShowMenuView();
        return ExtConsole.TakeInt32("Обраний пункт меню")
            .AsNotNull()
            .BelongsToSet(_items.Keys);
    }
}