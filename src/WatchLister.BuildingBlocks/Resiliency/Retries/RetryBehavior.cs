namespace WatchLister.BuildingBlocks.Resiliency.Retries;

public class RetryBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<RetryBehavior<TRequest, TResponse>> _logger;
    private readonly IEnumerable<IRetrievableRequest<TRequest, TResponse>> _retryHandlers;

    public RetryBehavior(IEnumerable<IRetrievableRequest<TRequest, TResponse>> retryHandlers,
        ILogger<RetryBehavior<TRequest, TResponse>> logger)
    {
        _retryHandlers = retryHandlers;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken
        cancellationToken)
    {
        var retryHandler = _retryHandlers.FirstOrDefault();

        if (retryHandler == null)
        {
            return await next();
        }

        var circuitBreaker = Policy<TResponse>
            .Handle<Exception>()
            .CircuitBreakerAsync(retryHandler.ExceptionsAllowedBeforeCircuitTrip, TimeSpan.FromMilliseconds(5000),
                (_, _) => { _logger.LogDebug("Circuit Tripped!"); },
                () => { });

        var retryPolicy = Policy<TResponse>
            .Handle<Exception>()
            .WaitAndRetryAsync(retryHandler.RetryAttempts, retryAttempt =>
            {
                var retryDelay = retryHandler.RetryWithExponentialBackOff
                    ? TimeSpan.FromMilliseconds(Math.Pow(2, retryAttempt) * retryHandler.RetryDelay)
                    : TimeSpan.FromMilliseconds(retryHandler.RetryDelay);

                _logger.LogDebug("Retrying, waiting {RetryDelay}...", retryDelay);

                return retryDelay;
            });

        var response = await retryPolicy.ExecuteAsync(async () => await next());

        return response;
    }
}