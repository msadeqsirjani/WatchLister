namespace WatchLister.BuildingBlocks.Exceptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message) : base(message) { }
}