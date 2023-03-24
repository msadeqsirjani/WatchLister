namespace WatchLister.BuildingBlocks.EfCore;

public static class QueryableExtensions
{
    public static async Task<ListResultModel<T>> PaginateAsync<T>(this IQueryable<T> collection, IPageList query)
        where T : notnull => await collection.PaginateAsync(query.Page, query.Size);

    public static async Task<ListResultModel<T>> PaginateAsync<T>(this IQueryable<T> collection, int page = 1,
        int size = 10) where T : notnull
    {
        if (page <= 0) page = 1;

        if (size <= 0) size = 10;

        var isEmpty = await collection.AnyAsync() == false;
        if (isEmpty) return ListResultModel<T>.Empty;

        var totalItems = await collection.CountAsync();
        var totalPages = (int) Math.Ceiling((decimal) totalItems / size);
        var data = await collection.Limit(page, size).ToListAsync();

        return ListResultModel<T>.Create(data, totalItems, page, size);
    }

    public static IQueryable<T> Limit<T>(this IQueryable<T> collection, IPageList query) => collection.Limit(query.Page, query.Size);

    public static IQueryable<T> Limit<T>(this IQueryable<T> collection, int page = 1, int size = 10)
    {
        if (page <= 0) page = 1;

        if (size <= 0) size = 10;

        var skip = (page - 1) * size;
        var data = collection.Skip(skip).Take(size);

        return data;
    }
}