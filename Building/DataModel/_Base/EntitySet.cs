using System;
using System.Collections;

namespace Building.DataModel;
public class EntitySet<T> : IEnumerable<T> where T : Entity
{
    public String Name { get; init; }

    public EntitySet(String name)
    {
        Name = name;
    }

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

    public void ForEach(Action<T> action)
    {
        foreach(T item in _items.Values) action(item);
    }
}
