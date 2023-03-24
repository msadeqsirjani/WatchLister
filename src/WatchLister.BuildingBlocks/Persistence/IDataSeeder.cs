namespace WatchLister.BuildingBlocks.Persistence;

public interface IDataSeeder
{
    Task SeedAsync();
}