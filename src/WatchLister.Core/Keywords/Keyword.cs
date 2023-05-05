namespace WatchLister.Core.Keywords;

public class Keyword : IEqualityComparer<Keyword>
{
    public Keyword(int id, string name)
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    ///     The keyword Id as identified by theMovieDB.org.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     The keyword.
    /// </summary>
    public string Name { get; init; }

    public bool Equals(Keyword? x, Keyword? y) => x != null && y != null && x.Id == y.Id && x.Name == y.Name;

    public int GetHashCode(Keyword obj)
    {
        unchecked // Overflow is fine, just wrap
        {
            var hash = 17;
            hash = hash * 23 + obj.Id.GetHashCode();
            hash = hash * 23 + obj.Name.GetHashCode();
            return hash;
        }
    }

    public override bool Equals(object? obj) => obj is Keyword genre && Equals(this, genre);

    public override int GetHashCode() => GetHashCode(this);

    public override string ToString() => $"{Name} ({Id})";
}