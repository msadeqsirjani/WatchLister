namespace WatchLister.BuildingBlocks.Caching;

public static class CacheKey
{
    public static string With(params string[] keys) => string.Join(",", keys);
    public static string With(Type ownerType, params string[] keys) => With($"{ownerType.GetCacheKey()}:{With(keys)}");
}