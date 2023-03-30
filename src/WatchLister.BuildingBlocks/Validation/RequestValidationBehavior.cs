namespace WatchLister.BuildingBlocks.Validation;

public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    private readonly ILogger<RequestValidationBehavior<TRequest, TResponse>> _logger;
    private readonly IServiceProvider _provider;
    private IValidator<TRequest>? _validator;

    public RequestValidationBehavior(IServiceProvider provider,
        ILogger<RequestValidationBehavior<TRequest, TResponse>> logger)
    {
        ArgumentNullException.ThrowIfNull(nameof(provider));
        ArgumentNullException.ThrowIfNull(nameof(logger));

        _provider = provider;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _validator = _provider.GetService<IValidator<TRequest>>();
        
        if (_validator == null)
        {
            return await next();
        }

        _logger.LogInformation("[{Prefix}] Handle request={X-RequestData} and response={X-ResponseData}",
            nameof(RequestValidationBehavior<TRequest, TResponse>), typeof(TRequest).Name, typeof(TResponse).Name);

        _logger.LogDebug("Handling {FullName} with content {Serialize}", 
            typeof(TRequest).FullName, JsonSerializer.Serialize(request));

        await _validator.HandleValidationAsync(request);

        var response = await next();

        _logger.LogInformation("Handled {FullName}", typeof(TRequest).FullName);

        return response;
    }
}