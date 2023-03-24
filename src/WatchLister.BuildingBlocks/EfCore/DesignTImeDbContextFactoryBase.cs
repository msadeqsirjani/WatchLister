namespace WatchLister.BuildingBlocks.EfCore;

public abstract class DesignTImeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
{
    public TContext CreateDbContext(string[] args)
    {
        var path = Directory.GetCurrentDirectory();
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        return Create(path, env);
    }

    protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

    public TContext Create()
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var path = AppContext.BaseDirectory;
        return Create(path, env);
    }

    public TContext Create(string path, string? env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(path)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env}.json", true)
            .AddEnvironmentVariables();

        var config = builder.Build();
        var connectionString = config.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Could not find a connection string named 'Default'");
        }

        return Create(connectionString);
    }

    public TContext Create(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException($"{nameof(connectionString)} is null or empty", nameof(connectionString));
        }

        var optionsBuilder = new DbContextOptionsBuilder<TContext>();

        Console.WriteLine("DesignTimeDbContextFactory.Create(string): Connection String: {0}", connectionString);

        optionsBuilder.UseSqlServer(connectionString);

        var options = optionsBuilder.Options;

        return CreateNewInstance(options);
    }
}