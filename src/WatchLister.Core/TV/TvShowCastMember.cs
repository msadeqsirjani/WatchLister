namespace WatchLister.Core.TV;

public class TvShowCastMember
{
    public int Id { get; init; }
    public string CreditId { get; init; } = string.Empty;
    public string Character { get; init; }
    public Gender Gender { get; init; }
    public string Name { get; init; }
    public bool Adult { get; init; }
    public int Order { get; init; }
    public string ProfilePath { get; init; } = string.Empty;
    public string KnownForDepartment { get; init; } = string.Empty;
    public string OriginalName { get; init; } = string.Empty;
    public float Popularity { get; init; }

    public override string ToString() => $"{Character}: {Name}";
}