namespace WatchLister.BuildingBlocks.Validation;

public static class ValidationExtensions
{
    public static async Task HandleValidationAsync<TRequest>(this IValidator<TRequest> validator, TRequest request)
    {
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToValidationResultModel());
        }
    }

    public static IServiceCollection AddCustomValidators(this IServiceCollection services, Assembly assembly)
    {
        return services.AddValidatorsFromAssembly(assembly);
    }

    private static ValidationResultModel ToValidationResultModel(this ValidationResult validationResult) => new(validationResult);
}