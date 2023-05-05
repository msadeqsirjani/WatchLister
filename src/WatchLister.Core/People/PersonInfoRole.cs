namespace WatchLister.Core.People;

public class PersonInfoRole
{
    public PersonInfoRole()
    {
        GenreIds = Array.Empty<int>();
        Genres = Array.Empty<Genres.Genre>();
        OriginCountry = Array.Empty<string>();
    }

    /// <summary>
    ///     The MovieId or TVShowId as defined by the value of <see cref="MediaType" />.
    /// </summary>
    public int Id { get; init; }

    public MediaType MediaType { get; init; }

    /// <summary>
    ///     Only populated when <see cref="MediaType" /> is TV.
    /// </summary>
    public string TvShowName { get; init; }

    /// <summary>
    ///     Only populated when <see cref="MediaType" /> is TV.
    /// </summary>
    public string TvShowOriginalName { get; init; } = string.Empty;

    /// <summary>
    ///     Only populated when <see cref="MediaType" /> is Movie.
    /// </summary>
    public string MovieTitle { get; init; }

    /// <summary>
    ///     Only populated when <see cref="MediaType" /> is Movie.
    /// </summary>
    public string MovieOriginalTitle { init; get; }

    public string BackdropPath { get; init; }

    public string PosterPath { get; init; }

    /// <summary>
    ///     Only populated when <see cref="MediaType" /> is Movie.
    /// </summary>
    public DateTime MovieReleaseDate { get; init; }

    /// <summary>
    ///     Only populated when <see cref="MediaType" /> is TV.
    /// </summary>
    public DateTime TVShowFirstAirDate { get; init; }

    public string Overview { get; init; }
    public bool IsAdultThemed { get; init; }
    public bool IsVideo { get; init; }
    public IReadOnlyList<int> GenreIds { get; init; }
    public IReadOnlyList<Genres.Genre> Genres { get; init; }
    public string OriginalLanguage { get; init; }
    public double Popularity { get; init; }
    public int VoteCount { get; init; }
    public double VoteAverage { get; init; }
    public IReadOnlyList<string> OriginCountry { get; init; }

    public override string ToString() =>
        MediaType == MediaType.Movie
            ? $"Movie: {MovieTitle} ({Id} - {MovieReleaseDate:yyyy-MM-dd})"
            : $"TV: {TvShowName} ({Id} - {TVShowFirstAirDate:yyyy-MM-dd})";
}