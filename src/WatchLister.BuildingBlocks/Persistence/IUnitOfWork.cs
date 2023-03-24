namespace WatchLister.BuildingBlocks.Persistence;

public interface IUnitOfWork : IDisposable
{
    Task<bool> CommitAsync();
}