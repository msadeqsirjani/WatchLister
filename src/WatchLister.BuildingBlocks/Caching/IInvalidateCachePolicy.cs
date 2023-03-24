namespace WatchLister.BuildingBlocks.Caching;

public interface IInvalidateCachePolicy<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
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

public interface IInvalidateCachePolicy<in TRequest> : IInvalidateCachePolicy<TRequest, Unit> where TRequest : IRequest<Unit>
{

}