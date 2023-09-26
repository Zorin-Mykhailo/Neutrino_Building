using System.Collections;

namespace Building;
public class EntitySet<T> : IEnumerable<T> where T : Entity
{
    public Int32 Id { get; init; }

    public String Name { get; init; }

    protected Menu? Menu { get; set; }

    public EntitySet(Int32 id, String name)
    {
        Id = id;
        Name = name;
        Menu = null;
    }

    public void ShowMenu()
    {
        if(Menu == null) return;
        EWorkWithMenu workWithMenu = EWorkWithMenu.QuitMenu;
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

        } while(workWithMenu == EWorkWithMenu.ContinueWork);
    }

    protected virtual EWorkWithMenu HandleMenuChoice(Int32 menuItemNumber)
        => Menu == null || menuItemNumber == 0 || !Menu.ContainsKey(menuItemNumber) ? EWorkWithMenu.QuitMenu : EWorkWithMenu.ContinueWork;

    private Dictionary<Int32, T> _items = new();

    public T this[Int32 id]
    {
        get => _items[id];
        set => _items[id] = value;
    }

    public Int32 Count => _items.Count;    
    
    public void Add(T item) => _items.Add(item.Id, item);
    
    public void Clear() => _items.Clear();
    
    public Boolean Contains(T item) => _items.ContainsKey(item.Id);
    
    public Boolean Remove(T item) => _items.ContainsKey(item.Id) && _items.Remove(item.Id);

    public Boolean Remove(Int32 itemId) => _items.ContainsKey(itemId) && _items.Remove(itemId);

    public IEnumerator<T> GetEnumerator() => _items.Values.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => _items.Values.GetEnumerator();

    public override String ToString() => $" {Id, 4} | {Name}";

    public virtual String ToEntitiesView(String header)
        => ToEntitiesView(header, _items.Values);

    public virtual String ToEntitiesView(String header, IEnumerable<T> entities)
        => header + (String.IsNullOrEmpty(header) ? String.Empty : "\n") +  String.Join("\n", entities);
}
