namespace WatchLister.Core.People;

public class PersonMovieCastMember
{
    public int Id { get; init; }
    public bool Adult { get; init; }
    public string Character { get; init; }
    public string CreditId { get; init; }
    public string OriginalTitle { get; init; }
    public string PosterPath { get; init; }
    public DateTime? ReleaseDate { get; init; }
    public string Title { get; init; }
}