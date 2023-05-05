namespace WatchLister.Core.People;

public class PersonExternalIds : ExternalIds
{
    public string FacebookId { get; init; } = string.Empty;
    public string ImdbId { get; init; } = string.Empty;
    public string TwitterId { get; init; } = string.Empty;
    public string InstagramId { get; init; } = string.Empty;
}