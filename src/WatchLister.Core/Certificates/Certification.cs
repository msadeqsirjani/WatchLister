namespace WatchLister.Core.Certificates;

public class Certification
{
    public string Rating { get; set; } = string.Empty;
    public string Meaning { get; set; } = string.Empty;
    public int Order { get; set; }

    public override string ToString() => $"{Rating} {Meaning.Substring(75)}";
}