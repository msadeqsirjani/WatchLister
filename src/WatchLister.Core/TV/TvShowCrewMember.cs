namespace WatchLister.Core.TV;

public class TvShowCrewMember
{
    public int Id { get; init; }
    public string CreditId { get; init; } = string.Empty;
    public string Department { get; init; }
    public string Job { get; init; }
    public string Name { get; init; }

    public string ProfilePath { get; init; } = string.Empty;
    public Gender Gender { get; init; }
    public bool Adult { get; init; }
    public string KnownForDepartment { get; init; } = string.Empty;
    public string OriginalName { get; init; } = string.Empty;
    public float Popularity { get; init; }

    public override string ToString() => $"{Name} | {Department} | {Job}";
}