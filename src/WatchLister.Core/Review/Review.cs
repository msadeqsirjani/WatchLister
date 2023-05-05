namespace WatchLister.Core.Review;

public class Review
{
    public string Id { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
    public string Url { get; init; } = string.Empty;

    /// <summary>
    ///     A language code, e.g. en
    /// </summary>
    public string Iso6391 { get; init; } = string.Empty;

    public int MediaId { get; init; }
    public string MediaTitle { get; init; } = string.Empty;
    public MediaType MediaType { get; init; }
}