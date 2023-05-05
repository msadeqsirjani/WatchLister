namespace WatchLister.Core.Generals;

public class Country : IEqualityComparer<Country>
{
    public string Iso3166Code { get; init; }
    public string Name { get; init; }

    public bool Equals(Country? x, Country? y) => x != null && y != null && x.Iso3166Code == y.Iso3166Code && x.Name == y.Name;

    public int GetHashCode(Country obj)
    {
        unchecked // Overflow is fine, just wrap
        {
            var hash = 17;
            hash = hash * 23 + obj.Iso3166Code.GetHashCode();
            hash = hash * 23 + obj.Name.GetHashCode();
            return hash;
        }
    }

    public override bool Equals(object? obj) => obj is Country country && Equals(this, country);

    public override int GetHashCode() => GetHashCode(this);

    public override string ToString() => string.IsNullOrWhiteSpace(Name) ? "n/a" : $"{Name} ({Iso3166Code})";
}