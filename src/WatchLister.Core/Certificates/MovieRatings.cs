namespace WatchLister.Core.Certificates;

public class MovieRatings
{
    public MovieRatings()
    {
        UnitedStates = Array.Empty<Certification>();
        Canada = Array.Empty<Certification>();
        Australia = Array.Empty<Certification>();
        Germany = Array.Empty<Certification>();
        France = Array.Empty<Certification>();
        NewZealand = Array.Empty<Certification>();
        India = Array.Empty<Certification>();
        UnitedKingdom = Array.Empty<Certification>();
    }

    public IReadOnlyList<Certification> Australia { get; init; }
    public IReadOnlyList<Certification> Canada { get; init; }
    public IReadOnlyList<Certification> France { get; init; }
    public IReadOnlyList<Certification> Germany { get; init; }
    public IReadOnlyList<Certification> India { get; init; }
    public IReadOnlyList<Certification> NewZealand { get; init; }
    public IReadOnlyList<Certification> UnitedStates { get; init; }
    public IReadOnlyList<Certification> UnitedKingdom { get; init; }
}