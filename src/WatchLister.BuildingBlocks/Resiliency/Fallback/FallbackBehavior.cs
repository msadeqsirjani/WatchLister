namespace WatchLister.BuildingBlocks.Resiliency.Fallback;

public class FallbackBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IFallbackHandler<TRequest, TResponse>> _fallbackHandlers;
    private readonly ILogger<FallbackBehavior<TRequest, TResponse>> _logger;

    public FallbackBehavior(IEnumerable<IFallbackHandler<TRequest, TResponse>> fallbackHandlers,
        ILogger<FallbackBehavior<TRequest, TResponse>> logger)
    {
        _fallbackHandlers = fallbackHandlers;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var fallbackHandler = _fallbackHandlers.FirstOrDefault();

        if (fallbackHandler == null)
        {
            return await next();
        }

        var fallbackPolicy = Policy<TResponse>
            .Handle<Exception>()
            .FallbackAsync(async token =>
            {
                _logger.LogDebug("Initial handler failed. Falling back to `{FullName}@HandleFallback`",
                    fallbackHandler.GetType().FullName);
                return await fallbackHandler.HandleFallbackAsync(request, token).ConfigureAwait(false);
            });

        var response = await fallbackPolicy.ExecuteAsync(async () => await next());

        return response;
    }
}