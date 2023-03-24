namespace WatchLister.BuildingBlocks.Mongo;

public class MongoOptions
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public static Guid UniqueId { get; set; } = Guid.NewGuid();
}