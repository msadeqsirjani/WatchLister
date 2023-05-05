namespace WatchLister.Core.People;

public abstract class PersonTvCastMember
{
    public int Id { get; init; }
    public string Character { get; init; } = string.Empty;
    public string CreditId { get; init; } = string.Empty;
    public int EpisodeCount { get; init; } = string.Empty;
    public DateTime FirstAirDate { get; init; }
    public string Name { get; init; } = string.Empty;
    public string OriginalName { get; init; } = string.Empty;
    public string PosterPath { get; init; } = string.Empty;
}