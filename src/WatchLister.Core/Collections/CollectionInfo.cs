namespace WatchLister.Core.Collections;

public class CollectionInfo
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string PosterPath { get; init; } = string.Empty;
    public string BackdropPath { get; init; } = string.Empty;

    public override string ToString() => string.IsNullOrEmpty(Name) ? "n/a" : $"{Name} ({Id})";
}