namespace WatchLister.Core.People;

public class PersonInfo : MultiInfo
{
    public PersonInfo() => KnownFor = Array.Empty<PersonInfoRole>();

    public string Name { get; init; }
    public bool IsAdultFilmStar { get; init; }
    public IReadOnlyList<PersonInfoRole> KnownFor { get; init; }
    public string ProfilePath { get; init; }
    public override MediaType MediaType { get; init; } = MediaType.Person;

    public override string ToString() => $"{Name} ({Id})";
}