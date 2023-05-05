namespace WatchLister.Core.People;

public class PersonMovieCrewMember
{
    public int Id { get; init; }
    public bool Adult { get; init; }
    public string CreditId { get; init; } = string.Empty;
    public string Department { get; init; } = string.Empty;
    public string Job { get; init; } = string.Empty;
    public string OriginalTitle { get; init; } = string.Empty;
    public string PosterPath { get; init; } = string.Empty;
    public DateTime? ReleaseDate { get; init; }
    public string Title { get; init; } = string.Empty;
}