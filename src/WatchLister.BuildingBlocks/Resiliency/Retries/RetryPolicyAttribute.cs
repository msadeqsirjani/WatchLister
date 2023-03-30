namespace WatchLister.BuildingBlocks.Resiliency.Retries;

[AttributeUsage(AttributeTargets.Class)]
public class RetryPolicyAttribute : Attribute
{
    private int _retryCount = 3;
    private int _sleepDuration = 200;

    public int RetryCount
    {
        get => _retryCount;
        set
        {
            if (value < 1) throw new ArgumentException("Retry count must be higher than 1.", nameof(value));

            _retryCount = value;
        }
    }

    public int SleepDuration
    {
        get => _sleepDuration;
        set
        {
            if (value < 1) throw new ArgumentException("Sleep duration must be higher than 1ms.", nameof(value));

            _sleepDuration = value;
        }
    }
}