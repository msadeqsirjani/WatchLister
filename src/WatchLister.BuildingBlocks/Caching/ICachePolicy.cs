namespace WatchLister.BuildingBlocks.Caching;

public interface ICachePolicy<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    DateTime? AbsoluteExpirationRelativeToNow { get; }

    string GetCacheKey(TRequest request)
    {
        var obj = new { Request = request };
        var properties = obj.Request
            .GetType()
            .GetProperties()
            .Select(x => $"{x.Name}:{x.GetValue(obj.Request, null)}");
        return $"{typeof(TRequest).FullName}{{{string.Join(",", properties)}}}";
    }
}