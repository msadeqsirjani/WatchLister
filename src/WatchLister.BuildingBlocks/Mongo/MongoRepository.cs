namespace WatchLister.BuildingBlocks.Mongo;

public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregate
{
    private readonly IMongoDbContext _context;
    private readonly IMongoCollection<TEntity> _db;

    public MongoRepository(IMongoDbContext context)
    {
        _context = context;

        _db = _context.GetCollection<TEntity>();
    }

    public Task<TEntity> GetAsync(Guid id) => GetAsync(e => e.Id.Equals(id));

    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate) =>
        _db.Find(predicate).SingleOrDefaultAsync();


    public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) =>
        await _db.Find(predicate).ToListAsync();

    public IAsyncEnumerable<TEntity> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null) =>
        _db.AsQueryable().ToAsyncEnumerable();

    public Task<ListResultModel<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate, TQuery query) 
        where TQuery : IPageList => _db.AsQueryable().Where(predicate).PaginateAsync(query);

    public Task AddAsync(TEntity entity) => _db.InsertOneAsync(entity);

    public Task UpdateAsync(TEntity entity) => UpdateAsync(entity, e => e.Id.Equals(entity.Id));

    public Task UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate) => _db.ReplaceOneAsync(predicate, entity);

    public Task DeleteAsync(Guid id) => DeleteAsync(e => e.Id.Equals(id));

    public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate) => _db.DeleteOneAsync(predicate);

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate) => _db.Find(predicate).AnyAsync();

    public void Dispose() => _context?.Dispose();
}