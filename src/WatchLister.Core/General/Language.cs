namespace WatchLister.Core.General;

public class Language : IEqualityComparer<Language>
{
    public string Iso639Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public bool Equals(Language? x, Language? y)
    {
        return x != null &&
               y != null &&
               x.Iso639Code == y.Iso639Code &&
               x.Name == y.Name;
    }

    public int GetHashCode(Language obj)
    {
        unchecked
        {
            var hash = 17;
            hash = hash * 23 + obj.Iso639Code.GetHashCode();
            hash = hash * 23 + obj.Name.GetHashCode();
            return hash;
        }
    }

    public override bool Equals(object? obj) => obj is Language language && Equals(this, language);

    public override int GetHashCode() => GetHashCode(this);

    public override string ToString() => string.IsNullOrWhiteSpace(Name) ? "n/a" : $"{Name} ({Iso639Code})";
}