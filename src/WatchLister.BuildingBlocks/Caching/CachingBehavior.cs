namespace WatchLister.BuildingBlocks.Caching;

public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    private readonly IEnumerable<ICachePolicy<TRequest, TResponse>> _cachePolicies;
    private readonly IEasyCachingProvider _cachingProvider;
    private readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger;
    private readonly int _defaultCachingExpiration;

    public CachingBehavior(IEnumerable<ICachePolicy<TRequest, TResponse>> cachePolicies,
        IEasyCachingProviderFactory cachingFactory,
        ILogger<CachingBehavior<TRequest, TResponse>> logger)
    {
        _cachePolicies = cachePolicies;
        _cachingProvider = cachingFactory.GetCachingProvider("mem");
        _logger = logger;
        _defaultCachingExpiration = 1;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var cachePolicy = _cachePolicies.FirstOrDefault();

        if (cachePolicy == null)
        {
            return await next();
        }

        var cacheKey = cachePolicy.GetCacheKey(request);
        var cacheResponse = await _cachingProvider.GetAsync<TResponse>(cacheKey, cancellationToken);
        if (cacheResponse.Value != null)
        {
            _logger.LogDebug("Response retrieved {TRequest} from cache. CacheKey: {CacheKey}",
                typeof(TRequest).FullName, cacheResponse);

            return cacheResponse.Value;
        }

        var response = await next();

        var time = cachePolicy.AbsoluteExpirationRelativeToNow ?? DateTime.Now.AddHours(_defaultCachingExpiration);

        await _cachingProvider.SetAsync(cacheKey, response, time.TimeOfDay, cancellationToken);

        _logger.LogDebug("Caching response for {TRequest} with cache key: {CacheKey}",
            typeof(TRequest).FullName, cacheResponse);

        return response;
    }
}