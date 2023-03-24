namespace WatchLister.BuildingBlocks.Exceptions;

public class InvalidCommandException
{
    public InvalidCommandException(List<string> errors)
    {
        Errors = errors;
    }

    public List<string> Errors { get; }
}