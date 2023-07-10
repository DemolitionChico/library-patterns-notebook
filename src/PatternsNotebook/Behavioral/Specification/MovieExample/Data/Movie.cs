namespace PatternsNotebook.Behavioral.Specification.MovieExample;

// For the sake of simplicity this class is shared between the database and the business logic. 
// Such behavior might be allowed in small scale projects where the complexity remains low, 
// but in large projects this is not advised.
public sealed class Movie
{
    public string Id { get; init; } = null!;
    public string Title { get; init; } = null!;
    public DateOnly? Premiere { get; set; }
    public DateOnly? CdRelease { get; init; }
    public MPAARating MpaaRating { get; init; }
    public double Rating { get; init; }

    public Movie()
    {
    }

    public enum MPAARating
    {
        G = 1,
        PG = 2,
        PG13 = 3,
        R = 4,
        NC17 = 5
    }
}