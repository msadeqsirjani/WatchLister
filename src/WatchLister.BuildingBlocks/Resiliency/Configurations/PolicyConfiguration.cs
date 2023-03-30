namespace WatchLister.BuildingBlocks.Resiliency.Configurations;

public class PolicyConfiguration : ICircuitBreakerPolicyConfiguration, IRetryPolicyConfiguration, ITimeoutPolicy
{
    public int RetryCount { get; set; }
    public int BreakDuration { get; set; }
    public int TimeoutDuration { get; set; }
}