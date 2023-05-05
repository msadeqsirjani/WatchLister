using Google.Apis.YouTube.v3;

namespace WatchLister.Core;

public class YoutubeVideoOptions
{
    public string ApiKey { get; set; } = string.Empty;
    public string SearchPart { get; set; } = string.Empty;
    public string SearchType { get; set; } = string.Empty;
    public SearchResource.ListRequest.OrderEnum Order { get; set; }
}