namespace WatchLister.BuildingBlocks.Mongo;

public interface IMongoDbContext : IDisposable
{
    IMongoDatabase Database { get; }
    IMongoClient MongoClient { get; }
    Task BeginTransactionAsync();
    Task RollbackTransactionAsync();
    Task CommitTransactionAsync();
    IMongoCollection<T> GetCollection<T>();
}