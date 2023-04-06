namespace WatchLister.Core.People;

public class Person
{
    public Person()
    {
        AlsoKnownAs = new List<string>();
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IReadOnlyCollection<string> AlsoKnownAs { get; set; }
    public string? KnownForDepartment { get; set; }
    public bool Audit { get; set; }
    public string? Biography { get; set; }
    public DateTime? BirthDay { get; set; }
    public DateTime? DeathDay { get; set; }
    public Genre Genre { get; set; }
    public string? HomePage { get; set; }
    public string ImdbId { get; set; } = string.Empty;
    public string? PlaceOfBirth { get; set; }
    public double Popularity { get; set; }
    public string? ProfilePath { get; set; }

    public override string ToString() => Name;
}