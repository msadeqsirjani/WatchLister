namespace WatchLister.Core.Movies;

public class MovieCredit
{
    public int MovieId { get; init; }
    public IReadOnlyList<MovieCastMember> CastMembers { get; init; } = new List<MovieCastMember>();
    public IReadOnlyList<MovieCrewMember> CrewMembers { get; init; } = new List<MovieCrewMember>();
}