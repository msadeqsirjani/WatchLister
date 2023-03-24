namespace WatchLister.BuildingBlocks.Exceptions;

public class AppException : Exception
{
    public AppException(string message, string code = default!) : base(message) => Code = code;

    public virtual string Code { get; }
}