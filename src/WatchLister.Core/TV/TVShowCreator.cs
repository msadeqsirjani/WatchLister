namespace WatchLister.Core.TV;

public class TvShowCreator : IEqualityComparer<TvShowCreator>
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string ProfilePath { get; init; }= string.Empty;
    public string CreditId { get; init; }
    public Gender Gender { get; set; }

    public bool Equals(TvShowCreator? x, TvShowCreator? y) =>
        x != null && y != null && x.Id == y.Id && x.Name == y.Name && x.Gender == y.Gender && x.CreditId == y.CreditId;

    public int GetHashCode(TvShowCreator obj)
    {
        unchecked // Overflow is fine, just wrap
        {
            var hash = 17;
            hash = hash * 23 + obj.Id.GetHashCode();
            hash = hash * 23 + obj.Name.GetHashCode();
            return hash;
        }
    }

    public override bool Equals(object? obj) => obj is TvShowCreator showCreator && Equals(this, showCreator);

    public override int GetHashCode() => GetHashCode(this);

    public override string ToString() => $"{Name} ({Id})";
}