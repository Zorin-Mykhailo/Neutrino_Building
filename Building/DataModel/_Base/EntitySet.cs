using System.Collections;

namespace Building;
public class EntitySet<T> : IEnumerable<T> where T : Entity
{
    public int Id { get; init; }

    public string Name { get; init; }

    protected Menu? Menu { get; set; }

    public EntitySet(int id, string name)
    {
        Id = id;
        Name = name;
        Menu = null;
    }

    public void ShowMenu()
    {
        if(Menu == null) return;
        WorkWithMenu workWithMenu = WorkWithMenu.QuitMenu;
        do
        {
            try
            {
                workWithMenu = HandleMenuChoice(Menu.ShowMenu());
            }
            catch(Exception ex)
            {
                ExtConsole.ShowError(ex.Message);
            }

        } while(workWithMenu == WorkWithMenu.ContinueWork);
    }

    protected virtual WorkWithMenu HandleMenuChoice(int menuItemNumber)
        => Menu == null || menuItemNumber == 0 || !Menu.ContainsKey(menuItemNumber) ? WorkWithMenu.QuitMenu : WorkWithMenu.ContinueWork;

    private Dictionary<int, T> _items = new();

    public T this[int id]
    {
        get => _items[id];
        set => _items[id] = value;
    }

    public int Count => _items.Count;    
    
    public void Add(T item) => _items.Add(item.Id, item);
    
    public void Clear() => _items.Clear();
    
    public bool Contains(T item) => _items.ContainsKey(item.Id);
    
    public bool Remove(T item) => _items.ContainsKey(item.Id) && _items.Remove(item.Id);

    public bool Remove(int itemId) => _items.ContainsKey(itemId) && _items.Remove(itemId);

    public IEnumerator<T> GetEnumerator() => _items.Values.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => _items.Values.GetEnumerator();

    public override string ToString() => $" {Id, 4} | {Name}";

    public virtual string ToEntitiesView(string header)
        => ToEntitiesView(header, _items.Values);

    public virtual string ToEntitiesView(string header, IEnumerable<T> entities)
        => header + (string.IsNullOrEmpty(header) ? string.Empty : "\n") +  string.Join("\n", entities);
}
