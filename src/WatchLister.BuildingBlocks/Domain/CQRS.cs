namespace WatchLister.BuildingBlocks.Domain;

public interface ICommand<out T> : IRequest<T> where T : notnull { }

public interface ICommand : IRequest { }

public interface IQuery<out T> : IRequest<T> where T : notnull { }

public interface ICreateCommand<out TResponse> : ICommand<TResponse>, ITxRequest where TResponse : notnull { }

public interface ICreateCommand : IRequest, ITxRequest { }

public interface IUpdateCommand : ICommand, ITxRequest { }

public interface IUpdateCommand<out TResponse> : ICommand<TResponse>, ITxRequest where TResponse : notnull { }

public interface IDeleteCommand<TId, out TResponse> : ICommand<TResponse>
    where TId : struct
    where TResponse : notnull
{
    public TId Id { get; set; }
}

public interface IDeleteCommand<TId> : ICommand where TId : struct
{
    public TId Id { get; set; }
}

public interface IPageList
{
    public List<string> Includes { get; set; }
    public List<FilterModel> Filters { get; set; }
    public List<string> Sorts { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}

public interface IListQuery<out TResponse> : IQuery<TResponse>, IPageList where TResponse : notnull { }

public interface IItemQuery<TId, out TResponse> : IQuery<TResponse>
    where TId : struct
    where TResponse : notnull
{
    public List<string> Includes { get; set; }
    public TId Id { get; set; }
}

public record FilterModel(string FieldName, string Comparision, string FieldValue);

public record ListResultModel<T>(List<T> Items, long TotalItems, int Page, int PageSize) where T : notnull
{
    public static ListResultModel<T> Empty => new(Enumerable.Empty<T>().ToList(), 0, 0, 0);

    public static ListResultModel<T> Create(List<T> items, long totalItems = 0, int page = default, int size = 10) =>
        new(items, totalItems, page, size);

    public ListResultModel<TReturn> Map<TReturn>(Func<T, TReturn> map) where TReturn : notnull
        => ListResultModel<TReturn>.Create(Items.Select(map).ToList(), TotalItems, Page, PageSize);
}