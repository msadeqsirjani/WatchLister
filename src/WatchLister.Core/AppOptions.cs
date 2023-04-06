namespace WatchLister.Core;

public class AppOptions
{
    public string Name { get; set; } = string.Empty;
    public string ApiAddress { get; set; } = string.Empty;
    public string Instance { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public bool DisplayBanner { get; set; } = true;
    public bool DisplayVersion { get; set; } = true;
    public string Description { get; set; } = string.Empty;
}