namespace WatchLister.BuildingBlocks.Security.ApiKey;

public record ApiKey(int Id, string Owner, string Key, DateTime Created, IReadOnlyCollection<string> Roles)
{
    public string Owner { get; } = Owner ?? throw new ArgumentNullException(nameof(Owner));
    public string Key { get; } = Key ?? throw new ArgumentNullException(nameof(Key));
    public IReadOnlyCollection<string> Roles { get; } = Roles ?? throw new ArgumentNullException(nameof(Roles));
}