using System.Collections.Concurrent;

namespace WatchLister.BuildingBlocks.Utils;

public static class ReflectionHelpers
{
    private static readonly ConcurrentDictionary<Type, string> TypeCacheKeys = new();
    private static readonly ConcurrentDictionary<Type, string> PrettyPrintCache = new();

    public static string GetCacheKey(this Type type) => TypeCacheKeys.GetOrAdd(type, x => $"{x.PrettyPrint()}");

    public static string PrettyPrint(this Type type)
    {
        return PrettyPrintCache.GetOrAdd(
            type,
            x =>
            {
                try
                {
                    return PrettyPrintRecursive(x, 0);
                }
                catch (Exception)
                {
                    return x.Name;
                }
            });
    }

    private static string PrettyPrintRecursive(Type type, int depth)
    {
        if (depth > 3) return type.Name;

        var nameParts = type.Name.Split('`');
        if (nameParts.Length == 1) return nameParts[0];

        var genericArguments = type.GetTypeInfo().GetGenericArguments();
        return !type.IsConstructedGenericType
            ? $"{nameParts[0]}<{new string(',', genericArguments.Length - 1)}>"
            : $"{nameParts[0]}<{string.Join(",", genericArguments.Select(t => PrettyPrintRecursive(t, depth + 1)))}>";
    }
}