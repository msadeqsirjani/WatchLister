namespace WatchLister.Core.TV;

public class TvShowCredit
{
    public int TvShowId { get; init; }
    public IReadOnlyList<TvShowCastMember> CastMembers { get; init; } = new List<TvShowCastMember>();
    public IReadOnlyList<TvShowCrewMember> CrewMembers { get; init; } = new List<TvShowCrewMember>();
}