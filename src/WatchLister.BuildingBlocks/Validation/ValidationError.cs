namespace WatchLister.BuildingBlocks.Validation;

public class ValidationError
{
    public ValidationError(string? field, string message)
    {
        Field = field != string.Empty ? field : null;
        Message = message;
    }

    public string? Field { get; set; }
    public string Message { get; set; }
}