namespace WatchLister.Core.People;

public class PersonTvCrewMember
{
    public int Id { get; init; }
    public string CreditId { get; init; } = string.Empty;
    public string Department { get; init; } = string.Empty;
    public int EpisodeCount { get; init; }
    public DateTime FirstAirDate { get; init; }
    public string Job { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string OriginalName { get; init; } = string.Empty;
    public string PosterPath { get; init; } = string.Empty;
}