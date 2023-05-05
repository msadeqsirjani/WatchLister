namespace WatchLister.Core.Companies;

public class ParentCompany
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? LogoPath { get; init; }

    public override string ToString() => string.IsNullOrWhiteSpace(Name) ? "n/a" : $"{Name} ({Id})";
}