namespace WatchLister.Core.General;

public class ImageData
{
    public double AspectRatio { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public int Height { get; set; }
    public int Width { get; set; }
    public string Iso6391 { get; set; } = string.Empty;
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }
}