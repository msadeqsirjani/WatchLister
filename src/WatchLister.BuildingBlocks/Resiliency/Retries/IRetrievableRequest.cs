namespace WatchLister.BuildingBlocks.Resiliency.Retries;

public interface IRetrievableRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public int RetryAttempts => 1;
    public int RetryDelay => 250;
    public bool RetryWithExponentialBackOff => false;
    public int ExceptionsAllowedBeforeCircuitTrip => 1;
}