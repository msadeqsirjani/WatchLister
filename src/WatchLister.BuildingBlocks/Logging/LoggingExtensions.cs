namespace WatchLister.BuildingBlocks.Logging;

public static class LoggingExtensions
{
    private const string Template = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u4}] {Message:lj}{NewLine}{Exception}";

    public static WebApplicationBuilder AddSerilogLogging(this WebApplicationBuilder builder,
        Action<LoggerConfiguration?>? action = null)
    {
        builder.Host.UseSerilog((context, provider, configuration) =>
        {
            var options = context.Configuration.GetSection(nameof(LoggingOptions)).Get<LoggingOptions>();

            action?.Invoke(configuration);

            configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(provider)
                .Enrich.WithExceptionDetails()
                .Enrich.WithCorrelationId()
                .Enrich.FromLogContext();

            var level = Enum.TryParse<LogEventLevel>(options?.Level, true, out var logLevel)
                ? logLevel
                : LogEventLevel.Information;

            configuration
                .MinimumLevel.Is(level)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning);

            if (context.HostingEnvironment.IsDevelopment())
            {
                configuration.WriteTo.Async(x => x.SpectreConsole(options?.LogTemplate ?? Template, level));
            }
            else
            {
                if (!string.IsNullOrEmpty(options?.ElasticSearch))
                {
                    configuration.WriteTo.Async(x => x.Elasticsearch(options.ElasticSearch));
                }

                if (!string.IsNullOrEmpty(options?.SeqUrl))
                {
                    configuration.WriteTo.Async(x => x.Seq(options.SeqUrl));
                }
            }

            if (!string.IsNullOrEmpty(options?.LogPath))
            {
                configuration.WriteTo.File(path: options.LogPath,
                    outputTemplate: options.LogTemplate ?? Template,
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true
                );
            }
        });

        return builder;
    }
}