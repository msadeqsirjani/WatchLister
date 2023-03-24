namespace WatchLister.BuildingBlocks.Mongo;

public static class QueryableExtensions
{
    public static async Task<ListResultModel<T>> PaginateAsync<T>(this IMongoQueryable<T> collection, IPageList query)
        where T : notnull => await collection.PaginateAsync(query.Page, query.Size);

    public static async Task<ListResultModel<T>> PaginateAsync<T>(this IMongoQueryable<T> collection, int page = 1, int size = 10) 
        where T : notnull
    {
        if (page <= 0) page = 1;

        if (size <= 0) size = 10;

        var isEmpty = await collection.AnyAsync() == false;
        if (isEmpty) return ListResultModel<T>.Empty;

        var totalItems = await collection.CountAsync();
        var totalPages = (int) Math.Ceiling((decimal) totalItems / size);
        var data = collection.Limit(page, size).ToList();

        return ListResultModel<T>.Create(data, totalItems, page, size);
    }

    public static IMongoQueryable<T> Limit<T>(this IMongoQueryable<T> collection, IPageList query) 
        => collection.Limit(query.Page, query.Size);

    public static IMongoQueryable<T> Limit<T>(this IMongoQueryable<T> collection, int page = 1, int size = 10)
    {
        if (page <= 0) page = 1;

        if (size <= 0) size = 10;

        var skip = (page - 1) * size;
        var data = collection.Skip(skip).Take(size);

        return data;
    }
}