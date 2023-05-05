namespace WatchLister.Core.Generals;

public class Video
{
    public string Id { get; init; } = string.Empty;

    /// <summary>
    ///     A country code, e.g. US
    /// </summary>
    public string Iso31661 { get; init; } = string.Empty;

    /// <summary>
    ///     A language code, e.g. en
    /// </summary>
    public string Iso6391 { get; init; } = string.Empty;

    public string Key { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Site { get; init; } = string.Empty;
    public int Size { get; init; }
    public string Type { get; init; } = string.Empty;
    public DateTime? PublishedAt { get; init; }
}