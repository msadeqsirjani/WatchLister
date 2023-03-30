namespace WatchLister.BuildingBlocks.Swagger;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    protected readonly SwaggerOptions? _options;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider,
        IOptions<SwaggerOptions> options)
    {
        _provider = provider;
        _options = options.Value;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }

    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var text = new StringBuilder("An example application with OpenAPI, Swashbuckle, and API version.");
        var info = new OpenApiInfo
        {
            Version = description.ApiVersion.ToString(),
            Title = _options?.Title ?? "APIs",
            Description = "An application with Swagger, Swashbuckle, and API version.",
            Contact = new OpenApiContact { Name = "", Email = "" },
            License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
        };

        if (description.IsDeprecated)
        {
            text.Append("This API version has been deprecated.");
        }

        if (description.SunsetPolicy is { } policy)
        {
            if (policy.Date is { } when)
            {
                text.Append(" The API will be sunset on ")
                    .Append(when.Date.ToShortDateString())
                    .Append('.');
            }

            if (policy.HasLinks)
            {
                text.AppendLine();

                foreach (var link in policy.Links)
                {
                    if (link.Type != "text/html")
                    {
                        continue;
                    }

                    text.AppendLine();

                    if (link.Title.HasValue)
                    {
                        text.Append(link.Title.Value).Append(": ");
                    }

                    text.Append(link.LinkTarget.OriginalString);
                }
            }
        }

        info.Description = text.ToString();

        return info;
    }
}