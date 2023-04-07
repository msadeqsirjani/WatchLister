namespace WatchLister.Core.Companies;

public class Company
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Headquarters { get; init; } = string.Empty;
    public string Homepage { get; init; } = string.Empty;
    public string LogoPath { get; init; } = string.Empty;
    public string OriginCountry { get; init; } = string.Empty;
    public ParentCompany? ParentCompany { get; init; }

    public override string ToString()
    {
        return $"{Name} ({Id})";
    }
}