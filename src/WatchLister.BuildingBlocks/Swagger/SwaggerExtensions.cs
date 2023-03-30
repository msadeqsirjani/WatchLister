namespace WatchLister.BuildingBlocks.Swagger;

public static class SwaggerExtensions
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {
        services.AddEndpointsApiExplorer();

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddOptions<SwaggerOptions>().Bind(configuration.GetSection(nameof(SwaggerOptions)))
            .ValidateDataAnnotations();

        services.AddSwaggerGen(
            options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();

                var xmlFile = XmlCommentsFilePath(assembly);

                if (File.Exists(xmlFile))
                {
                    options.IncludeXmlComments(xmlFile);
                }

                var bearerScheme = new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Name = JwtBearerDefaults.AuthenticationScheme,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                };

                var apiKeyScheme = new OpenApiSecurityScheme
                {
                    Description = "Api key needed to access the endpoints. X-Api-Key: My_API_Key",
                    In = ParameterLocation.Header,
                    Name = "X-Api-Key",
                    Scheme = "ApiKey",
                    Type = SecuritySchemeType.ApiKey,
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "X-Api-Key"
                    }
                };

                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, bearerScheme);
                options.AddSecurityDefinition("X-Api-Key", apiKeyScheme);

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {bearerScheme, Array.Empty<string>()}, {apiKeyScheme, Array.Empty<string>()}
                });

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                options.EnableAnnotations();
            });

        static string XmlCommentsFilePath(Assembly assembly)
        {
            var basePath = Path.GetDirectoryName(assembly.Location);

            ArgumentNullException.ThrowIfNull(nameof(basePath));

            var fileName = $"{assembly.GetName().Name}.xml";
            return Path.Combine(basePath!, fileName);
        }

        return services;
    }

    public static WebApplication UseCustomSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
            {
                var descriptions = app.DescribeApiVersions();

                foreach (var description in descriptions)
                {
                    var url = $"/swagger/{description.GroupName}/swagger.json";
                    var name = description.GroupName.ToUpperInvariant();
                    options.SwaggerEndpoint(url, name);
                }
            });

        return app;
    }
}