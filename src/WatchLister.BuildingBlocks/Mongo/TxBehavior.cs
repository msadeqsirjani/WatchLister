namespace WatchLister.BuildingBlocks.Mongo;

public class TxBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    private readonly IMongoDbContext _dbContext;
    private readonly ILogger<TxBehavior<TRequest, TResponse>> _logger;

    public TxBehavior(IMongoDbContext dbContext, ILogger<TxBehavior<TRequest, TResponse>> logger)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbContext = dbContext;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken
        cancellationToken)
    {
        if (request is not ITxRequest) return await next();

        _logger.LogInformation("{Prefix} Handled command {Request}", nameof(TxBehavior<TRequest, TResponse>), typeof(TRequest).FullName);
        _logger.LogDebug("{Prefix} Handled command {Request} with content {RequestContent}", 
            nameof(TxBehavior<TRequest, TResponse>), typeof(TRequest).FullName, JsonSerializer.Serialize(request));
        _logger.LogInformation("{Prefix} Open the transaction for {Request}", nameof(TxBehavior<TRequest, TResponse>), typeof(TRequest).FullName);

        try
        {
            await _dbContext.BeginTransactionAsync();

            var response = await next();
            
            _logger.LogInformation("{Prefix} Executed the {Request} request", nameof(TxBehavior<TRequest, TResponse>), typeof(TRequest).FullName);

            await _dbContext.CommitTransactionAsync();

            return response;
        }
        catch (Exception)
        {
            await _dbContext.RollbackTransactionAsync();
            throw;
        }
    }
}