namespace WatchLister.BuildingBlocks.Caching;

public class InvalidateCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    private readonly IEasyCachingProvider _cachingProvider;
    private readonly IEnumerable<IInvalidateCachePolicy<TRequest, TResponse>> _invalidateCachePolicies;
    private readonly ILogger<InvalidateCacheBehavior<TRequest, TResponse>> _logger;

    public InvalidateCacheBehavior(IEasyCachingProviderFactory cachingFactory,
        IEnumerable<IInvalidateCachePolicy<TRequest, TResponse>> invalidateCachePolicies,
        ILogger<InvalidateCacheBehavior<TRequest, TResponse>> logger)
    {
        _cachingProvider = cachingFactory.GetCachingProvider("mem");
        _invalidateCachePolicies = invalidateCachePolicies;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var cachePolicy = _invalidateCachePolicies.FirstOrDefault();

        if (cachePolicy == null)
        {
            return await next();
        }

        var cacheKey = cachePolicy.GetCacheKey(request);
        var response = await next();

        await _cachingProvider.RemoveAsync(cacheKey, cancellationToken);

        _logger.LogDebug("Cache date with cache key {CacheKey} removed", cacheKey);

        return response;
    }
}