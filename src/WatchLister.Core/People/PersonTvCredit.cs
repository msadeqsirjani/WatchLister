namespace WatchLister.Core.People;

public class PersonTvCredit
{
    public PersonTvCredit()
    {
        CastRoles = Array.Empty<PersonTvCastMember>();
        CrewRoles = Array.Empty<PersonTvCrewMember>();
    }

    public int PersonId { get; init; }
    public IReadOnlyList<PersonTvCastMember> CastRoles { get; init; }
    public IReadOnlyList<PersonTvCrewMember> CrewRoles { get; init; }
}