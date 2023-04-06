namespace WatchLister.Core.General;

public class Country : IEqualityComparer<Country>
{
    public string Iso3166Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public bool Equals(Country? x, Country? y)
    {
        return x != null &&
               y != null &&
               x.Iso3166Code == y.Iso3166Code &&
               x.Name == y.Name;
    }

    public int GetHashCode(Country obj)
    {
        unchecked
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