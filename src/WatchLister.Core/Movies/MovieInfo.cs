namespace WatchLister.Core.Movies;

public class MovieInfo : MultiInfo
{
    public MovieInfo() => GenreIds = Array.Empty<int>();

    public string Title { get; init; }
    public bool Adult { get; init; }
    public string BackdropPath { get; init; }
    public IReadOnlyList<int> GenreIds { get; init; }
    public string OriginalTitle { get; init; }
    public string OriginalLanguage { get; init; }
    public string Overview { get; init; }
    public override MediaType MediaType { get; init; } = MediaType.Movie;
    public DateTime ReleaseDate { get; init; }
    public string PosterPath { get; init; }
    public bool Video { get; init; }
    public double VoteAverage { get; init; }
    public int VoteCount { get; init; }

    public override string ToString() => $"{Title} ({Id} - {ReleaseDate:yyyy-MM-dd})";
}