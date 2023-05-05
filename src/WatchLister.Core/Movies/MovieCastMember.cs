namespace WatchLister.Core.Movies;

public class MovieCastMember
{
    public int Id { get; init; }
    public int CastId { get; init; }
    public string CreditId { get; init; } = string.Empty;
    public string Character { get; init; } = string.Empty;
    public Gender Gender { get; init; }
    public bool Adult { get; init; }
    public string Name { get; init; } = string.Empty;
    public string KnownForDepartment { get; init; } = String.Empty;
    public string OriginalName { get; init; } = string.Empty;
    public float Popularity { get; init; }
    public int Order { get; init; }
    public string? ProfilePath { get; init; }

    public override string ToString() => $"{Character}: {Name}";
}