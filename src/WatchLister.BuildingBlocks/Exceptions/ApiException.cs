namespace WatchLister.BuildingBlocks.Exceptions;

public class ApiException : ApplicationException
{
    public ApiException() { }

    public ApiException(string message) : base(message) { }

    public ApiException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }
}