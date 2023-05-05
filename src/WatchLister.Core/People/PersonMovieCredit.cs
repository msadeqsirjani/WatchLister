namespace WatchLister.Core.People;

public class PersonMovieCredit
{
    public PersonMovieCredit()
    {
        CastRoles = Array.Empty<PersonMovieCastMember>();
        CrewRoles = Array.Empty<PersonMovieCrewMember>();
    }

    public int PersonId { get; init; }
    public IReadOnlyList<PersonMovieCastMember> CastRoles { get; init; }
    public IReadOnlyList<PersonMovieCrewMember> CrewRoles { get; init; }
}