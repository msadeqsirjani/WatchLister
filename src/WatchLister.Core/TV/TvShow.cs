﻿using Genre = WatchLister.Core.Genres.Genre;

namespace WatchLister.Core.TV;

public class TvShow
{
    public TvShow()
    {
        CreatedBy = Array.Empty<TvShowCreator>();
        EpisodeRunTime = Array.Empty<int>();
        Genres = Array.Empty<Genre>();
        Languages = Array.Empty<string>();
        Networks = Array.Empty<Network>();
        OriginCountry = Array.Empty<string>();
        ProductionCompanies = Array.Empty<ProductionCompany>();
        Seasons = Array.Empty<Season>();
        Keywords = Array.Empty<Keyword>();
    }

    public int Id { get; init; }
    public string BackdropPath { get; init; }
    public IReadOnlyList<TvShowCreator> CreatedBy { get; init; }
    public IReadOnlyList<int> EpisodeRunTime { get; init; }
    public DateTime FirstAirDate { get; init; }
    public IReadOnlyList<Genre> Genres { get; init; }
    public string Homepage { get; init; }
    public bool InProduction { get; init; }
    public IReadOnlyList<string> Languages { get; init; }
    public DateTime LastAirDate { get; init; }
    public string Name { get; init; }
    public IReadOnlyList<Network> Networks { get; init; }
    public int NumberOfEpisodes { get; init; }
    public int NumberOfSeasons { get; init; }
    public IReadOnlyList<string> OriginCountry { get; init; }
    public string OriginalLanguage { get; init; }
    public string OriginalName { get; init; }
    public string Overview { get; init; }
    public double Popularity { get; init; }
    public string PosterPath { get; init; }
    public IReadOnlyList<ProductionCompany> ProductionCompanies { get; init; }
    public IReadOnlyList<Country> ProductionCountries { get; init; }
    public IReadOnlyList<Season> Seasons { get; init; }
    public IReadOnlyList<Keyword> Keywords { get; init; }

    public override string ToString() => $"{Name} ({FirstAirDate:yyyy-MM-dd}) [{Id}]";
}