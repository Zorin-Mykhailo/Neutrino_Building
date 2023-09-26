using System;
namespace Building.DataModel.Articles;

public class Article : Entity
{
    public DateTime CreationTime { get; set; }

    public required String Title { get; init; }

    public String? Content { get; init; }

    public Article(Int32 id, DateTime creationTime) : base(id)
        => CreationTime = creationTime;

    public Article(Int32 id) : base(id)
        => CreationTime = DateTime.Now;

    public override String ToString() 
        => $"{base.ToString()} 📝 [{CreationTime:yyyy.MM.dd(ddd) HH:mm}] {Title}";
}
