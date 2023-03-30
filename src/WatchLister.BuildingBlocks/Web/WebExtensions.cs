namespace WatchLister.BuildingBlocks.Web;

public static class WebExtensions
{
    public static void AddCustomVersion(this IServiceCollection services, Action<ApiVersioningOptions>? configurator = null)
    {
        services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;

                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);

                options.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader("api-version"),
                    new QueryStringApiVersionReader(), new UrlSegmentApiVersionReader());

                configurator?.Invoke(options);
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            })
            .AddMvc();
    }

    public static IServiceCollection AddCustomHealthCheck(this IServiceCollection services, Action<IHealthChecksBuilder>? configurator = null)
    {
        var healCheckBuilder = services.AddHealthChecks();
        
        configurator?.Invoke(healCheckBuilder);

        services.AddHealthChecksUI(setup =>
        {
            setup.SetEvaluationTimeInSeconds(60);
            setup.AddHealthCheckEndpoint("Basic Health Check", "/healthz");
        }).AddInMemoryStorage();

        return services;
    }


    public static void UnRegister<TService>(this IServiceCollection services)
    {
        var descriptor = services.FirstOrDefault(x => x.ServiceType == typeof(TService));
        services.Remove(descriptor);
    }

    public static void Replace<TService, TImplementation>(this IServiceCollection services, ServiceLifetime lifetime)
    {
        services.UnRegister<TService>();
        services.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), lifetime));
    }

    /// <summary>
    ///     Adds a new transient registration to the service collection only when no existing registration of the same service
    ///     type and implementation type exists.
    ///     In contrast to TryAddTransient, which only checks the service type.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="serviceType">Service type</param>
    /// <param name="implementationType">Implementation type</param>
    private static void TryAddTransientExact(this IServiceCollection services, Type serviceType,
        Type implementationType)
    {
        if (services.Any(reg => reg.ServiceType == serviceType && reg.ImplementationType == implementationType)) return;

        services.AddTransient(serviceType, implementationType);
    }

    /// <summary>
    ///     Adds a new transient registration to the service collection only when no existing registration of the same service
    ///     type and implementation type exists.
    ///     In contrast to TryAddScoped, which only checks the service type.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="serviceType">Service type</param>
    /// <param name="implementationType">Implementation type</param>
    private static void TryAddScopeExact(this IServiceCollection services, Type serviceType,
        Type implementationType)
    {
        if (services.Any(reg => reg.ServiceType == serviceType && reg.ImplementationType == implementationType)) return;

        services.AddScoped(serviceType, implementationType);
    }

    /// <summary>
    ///     Adds a new transient registration to the service collection only when no existing registration of the same service
    ///     type and implementation type exists.
    ///     In contrast to TryAddSingleton, which only checks the service type.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="serviceType">Service type</param>
    /// <param name="implementationType">Implementation type</param>
    private static void TryAddSingletonExact(this IServiceCollection services, Type serviceType,
        Type implementationType)
    {
        if (services.Any(reg => reg.ServiceType == serviceType && reg.ImplementationType == implementationType)) return;

        services.AddSingleton(serviceType, implementationType);
    }

    public static void ReplaceScoped<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        services.UnRegister<TService>();
        services.AddScoped<TService, TImplementation>();
    }

    public static void ReplaceScoped<TService>(this IServiceCollection services,
        Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        services.UnRegister<TService>();
        services.AddScoped(implementationFactory);
    }

    public static void ReplaceTransient<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        services.UnRegister<TService>();
        services.AddTransient<TService, TImplementation>();
    }

    public static void ReplaceTransient<TService>(this IServiceCollection services,
        Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        services.UnRegister<TService>();
        services.AddTransient(implementationFactory);
    }

    public static void ReplaceSingleton<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        services.UnRegister<TService>();
        services.AddSingleton<TService, TImplementation>();
    }

    public static void ReplaceSingleton<TService>(this IServiceCollection services,
        Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        services.UnRegister<TService>();
        services.AddSingleton(implementationFactory);
    }

    public static void RegisterOptions<TOptions>(this IServiceCollection services, IConfiguration configuration)
        where TOptions : class, new()
    {
        var options = new TOptions();
        configuration.Bind(typeof(TOptions).Name, options);

        services.AddSingleton(options);
    }

    public static void RegisterOptions<TOptions>(this IServiceCollection services, IConfiguration configuration,
        string name) where TOptions : class, new()
    {
        var options = new TOptions();
        configuration.Bind(name, options);

        services.AddSingleton(options);
    }
}