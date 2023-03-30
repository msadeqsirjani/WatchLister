namespace WatchLister.BuildingBlocks.Web;

public interface IPageRequest
{
    public List<string> Includes { get; set; }
    public List<FilterModel> Filters { get; set; }
    public List<string> Sorts { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}