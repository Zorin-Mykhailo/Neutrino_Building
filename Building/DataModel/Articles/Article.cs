namespace Building;

public class Article : Entity
{
    public DateTime CreationTime { get; set; }

    public required string Title { get; init; }

    public string? Content { get; init; }

    public Article(int id, DateTime creationTime) : base(id)
        => CreationTime = creationTime;

    public Article(int id) : base(id)
        => CreationTime = DateTime.Now;

    public override string ToString() 
        => $"{base.ToString()} 📝 {CreationTime:yyyy.MM.dd(ddd) HH:mm} -- {Title}";
}
