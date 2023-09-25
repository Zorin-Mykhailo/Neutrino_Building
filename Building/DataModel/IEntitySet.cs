namespace Building.DataModel;

public interface IEntitySet<T> where T : IEntity
{
    public Int32 GetNextFreeId();

    public T AddItem(T item);

    public void RemoveItem(T item);

    public T GetItem(Int32 id);

    public IEnumerable<T> GetItems(EActuality? eActuality);
}
