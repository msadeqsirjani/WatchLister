namespace WatchLister.BuildingBlocks.Resiliency.Configurations;

public interface ICircuitBreakerPolicyConfiguration
{
    public int RetryCount { get; }
    public int BreakDuration { get; }
}