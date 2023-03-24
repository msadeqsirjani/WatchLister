namespace WatchLister.BuildingBlocks.Caching;

public static class CachingExtensions
{
    public static IServiceCollection AddCachingRequestPolicies(this IServiceCollection services, IList<Assembly>? assemblies)
    {
        services.Scan(scan => scan
            .FromAssemblies(assemblies ?? AppDomain.CurrentDomain.GetAssemblies())
            .AddClasses(classes => classes.AssignableTo(typeof(ICachePolicy<,>)), false)
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.Scan(scan => scan
            .FromAssemblies(assemblies ?? AppDomain.CurrentDomain.GetAssemblies())
            .AddClasses(classes => classes.AssignableTo(typeof(IInvalidateCachePolicy<,>)),
                false)
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}