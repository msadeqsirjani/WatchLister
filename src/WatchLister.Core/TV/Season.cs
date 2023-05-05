namespace WatchLister.Core.TV;

public class Season
{
    public int Id { get; init; }
    public DateTime? AirDate { get; init; }
    public int EpisodeCount { get; init; }
    public string PosterPath { get; init; } = string.Empty;
    public string Overview { get; init; }= string.Empty;
    public int SeasonNumber { get; init; }

    public override string ToString() => $"({SeasonNumber} - {AirDate:yyyy-MM-dd})";
}