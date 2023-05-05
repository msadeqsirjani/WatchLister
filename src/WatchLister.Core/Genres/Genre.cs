namespace WatchLister.Core.Genres;

public class Genre : IEqualityComparer<Genre>
{
    public Genre(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; init; }

    public string Name { get; init; }

    public bool Equals(Genre? x, Genre? y) => x != null && y != null && x.Id == y.Id && x.Name == y.Name;

    public int GetHashCode(Genre obj)
    {
        unchecked // Overflow is fine, just wrap
        {
            var hash = 17;
            hash = hash * 23 + obj.Id.GetHashCode();
            hash = hash * 23 + obj.Name.GetHashCode();
            return hash;
        }
    }

    public override bool Equals(object? obj) => obj is Genre genre && Equals(this, genre);

    public override int GetHashCode() => GetHashCode(this);

    public override string ToString() => $"{Name} ({Id})";
}