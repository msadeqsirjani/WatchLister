namespace WatchLister.Core.Generals;

public class Language : IEqualityComparer<Language>
{
    public string Iso639Code { get; init; }
    public string Name { get; init; }

    public string? EnglishName { get; init; }

    public bool Equals(Language? x, Language? y) => x != null && y != null && x.Iso639Code == y.Iso639Code && x.Name == y.Name;

    public int GetHashCode(Language obj)
    {
        unchecked // Overflow is fine, just wrap
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