namespace WatchLister.Core.Companies;

public class ParentCompany
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string LogoPath { get; set; } = string.Empty;

    public override string ToString() => string.IsNullOrEmpty(Name) ? "n/a" : $"{Name} ({Id})";
}