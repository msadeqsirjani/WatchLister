namespace WatchLister.BuildingBlocks.Resiliency.Configurations;

public interface ITimeoutPolicy
{
    public int TimeoutDuration { get; }
}