namespace WatchLister.BuildingBlocks.Mongo;

public class MongoDbContext : IMongoDbContext
{
    public MongoDbContext(MongoOptions options)
    {
        RegisterConventions();

        MongoClient = new MongoClient(options.ConnectionString);
        Database = MongoClient.GetDatabase(options.DatabaseName);
    }

    public IClientSessionHandle Session { get; set; } = null!;
    public IMongoDatabase Database { get; set; }
    public IMongoClient MongoClient { get; set; }

    public async Task BeginTransactionAsync()
    {
        Session = await MongoClient.StartSessionAsync();
        Session.StartTransaction();
    }

    public async Task RollbackTransactionAsync() => await Session.AbortTransactionAsync();

    public async Task CommitTransactionAsync()
    {
        if (Session.IsInTransaction)
        {
            await Session.CommitTransactionAsync();
        }

        Session.Dispose();
    }

    public IMongoCollection<T> GetCollection<T>() => Database.GetCollection<T>(typeof(T).Name.ToLower());

    public void Dispose()
    {
        while (Session is { IsInTransaction: true })
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
        }

        GC.SuppressFinalize(this);
    }

    private static void RegisterConventions()
    {
        ConventionRegistry.Register("conventions", new ConventionPack
        {
            new CamelCaseElementNameConvention(),
            new IgnoreExtraElementsConvention(true),
            new EnumRepresentationConvention(BsonType.String),
            new IgnoreIfDefaultConvention(true),
            new ImmutablePocoConvention(),
        }, _ => true);
    }
}