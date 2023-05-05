namespace WatchLister.Core.Collections;

public class CollectionInfo
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? PosterPath { get; init; }
    public string? BackdropPath { get; init; }

    public override string ToString() => string.IsNullOrWhiteSpace(Name) ? "n/a" : $"{Name} ({Id})";
}