namespace WatchLister.BuildingBlocks.Mongo;

public static class MongoExtensions
{
    private const string SectionName = "Mongo";

    public static IServiceCollection AddMongoDbContext<TContext>(
        this IServiceCollection services, IConfiguration configuration,
        string sectionName = SectionName, Action<MongoOptions>? action = null)
        where TContext : MongoDbContext
    {
        return services.AddMongoDbContext<TContext, TContext>(configuration, sectionName, action);
    }

    public static IServiceCollection AddMongoDbContext<TContextService, TContextImplementation>(
        this IServiceCollection services, IConfiguration configuration,
        string sectionName = SectionName, Action<MongoOptions>? action = null)
        where TContextService : IMongoDbContext
        where TContextImplementation : MongoDbContext, TContextService
    {
        var mongoOptions = configuration.GetSection(sectionName).Get<MongoOptions>() ?? new MongoOptions();
        
        services.AddSingleton(mongoOptions);

        action?.Invoke(mongoOptions);

        services.AddScoped(typeof(TContextService), typeof(TContextImplementation));
        services.AddScoped(typeof(TContextImplementation));

        services.AddScoped<IMongoDbContext>(x => x.GetRequiredService<TContextService>());

        return services;
    }
}