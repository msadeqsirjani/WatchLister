namespace WatchLister.Core.Generals;

public class Images
{
    public int Id { get; set; }
    public List<ImageData> Backdrops { get; set; } = new();
    public List<ImageData> Posters { get; set; } = new();
}