namespace WatchLister.Core.Movies;

public class MovieCrewMember
{
    public int Id { get; init; }
    public string CreditId { get; init; } = string.Empty;
    public string Department { get; init; } = string.Empty;
    public string Job { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string? ProfilePath { get; init; }
    public Gender Gender { get; init; }
    public bool Adult { get; init; }
    public string? KnownForDepartment { get; init; }
    public string? OriginalName { get; init; }
    public float Popularity { get; init; }

    public override string ToString() => $"{Name} | {Department} | {Job}";
}