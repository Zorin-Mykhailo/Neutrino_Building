namespace Building.DataModel;

public class Entity : IEquatable<Entity?>
{
    public Int32 Id { get; init; }

    public EActuality Actuality { get; init; } = EActuality.Actual;

    public Entity(Int32 id)
    {
        Id = id;
    }


    public override Boolean Equals(Object? obj) => Equals(obj as Entity);

    public Boolean Equals(Entity? other) => other is not null && Id == other.Id;
    
    public override Int32 GetHashCode() => HashCode.Combine(Id);

    public static Boolean operator ==(Entity? left, Entity? right) => left is not null && right is not null && left.Id == right.Id;

    public static Boolean operator !=(Entity? left, Entity? right) => !(left == right);

    public override String ToString() => $"🔑 {Id,-6}";
}
