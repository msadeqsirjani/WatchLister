namespace WatchLister.Core.General;

public class Video
{
    public int Id { get; set; }
    public string Iso31661 { get; set; } = string.Empty;
    public string Iso6391 { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Site { get; set; }
    public int Size { get; set; }
    public string Type { get; set; } = string.Empty;
    public DateTime? PublishedAt { get; set; }
}