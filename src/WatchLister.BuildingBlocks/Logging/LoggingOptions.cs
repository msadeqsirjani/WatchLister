namespace WatchLister.BuildingBlocks.Logging;

public class LoggingOptions
{
    public string? Level { get; set; }
    public string? SeqUrl { get; set; }
    public string? ElasticSearch { get; set; }
    public string? LogTemplate { get; set; }
    public string? LogPath { get; set; }
}