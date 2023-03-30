namespace WatchLister.BuildingBlocks.Validation;

public class ValidationResultModel
{
    public ValidationResultModel(ValidationResult validationResult)
    {
        Errors = validationResult.Errors
            .Select(error => new ValidationError(error.PropertyName, error.ErrorMessage))
            .ToList();
    }

    public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;
    public string Message { get; set; } = "Validation Failed";
    public List<ValidationError> Errors { get; }

    public override string ToString() => JsonSerializer.Serialize(this);
}