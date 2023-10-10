namespace Building;

public class Entity : IEquatable<Entity?>
{
    public int Id { get; init; }

    public Actuality Actuality { get; init; } = Actuality.Actual;

    public Entity(int id)
    {
        Id = id;
    }


    public override bool Equals(object? obj) => Equals(obj as Entity);

    public bool Equals(Entity? other) => other is not null && Id == other.Id;
    
    public override int GetHashCode() => HashCode.Combine(Id);

    public static bool operator ==(Entity? left, Entity? right) => left is not null && right is not null && left.Id == right.Id;

    public static bool operator !=(Entity? left, Entity? right) => !(left == right);

    public override string ToString() => $"[{(Actuality == Actuality.Actual ? "✔️" : "⛔")} {Id,-6}]";

    public virtual string ToEntityView() => $"Entity {ToString()}";
}
