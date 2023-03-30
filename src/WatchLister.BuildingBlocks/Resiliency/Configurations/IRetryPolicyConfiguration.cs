namespace WatchLister.BuildingBlocks.Resiliency.Configurations;

public interface IRetryPolicyConfiguration
{
    public int RetryCount { get; }
}