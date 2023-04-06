namespace WatchLister.Core.General;

public class Image
{
    public Image()
    {
        Backdrops = new List<ImageData>();
        Posters = new List<ImageData>();
    }
    
    public int Id { get; set; }
    public List<ImageData> Backdrops { get; set; }
    public List<ImageData> Posters { get; set; }
}