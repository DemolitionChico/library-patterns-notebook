namespace PatternsNotebook.Behavioral.Specification.MovieExample.Database;

public class MovieDbContext
{
    public MovieDbContext()
    {
        
    }
    
    public IQueryable<Movie> Movies { get; } = new List<Movie>()
    {
        new Movie() {  Id = "001", Title = "Test movie 1", CdRelease = new DateOnly(2020, 12, 24), MpaaRating = Movie.MPAARating.G, Rating = 7.6, Premiere = new DateOnly(2018, 1, 1) },
        new Movie() {  Id = "002", Title = "Test movie 2", CdRelease = new DateOnly(2023, 6, 4), MpaaRating = Movie.MPAARating.NC17, Rating = 2, Premiere = new DateOnly(2023, 1, 1) },
        new Movie() {  Id = "003", Title = "Test movie 3", CdRelease = null, MpaaRating = Movie.MPAARating.PG13, Rating = 5.1, Premiere = DateOnly.FromDateTime(DateTime.Now).AddYears(1) },
        new Movie() {  Id = "004", Title = "Test movie 4 (extra)", CdRelease = new DateOnly(2010, 06, 14), MpaaRating = Movie.MPAARating.PG, Rating = 3.1, Premiere = new DateOnly(2008, 5, 12) },
        new Movie() {  Id = "005", Title = "Test movie 5 (extra)", CdRelease = new DateOnly(2000, 01, 7), MpaaRating = Movie.MPAARating.PG13, Rating = 4, Premiere = new DateOnly(1999, 3, 15) },
        new Movie() {  Id = "006", Title = "Test movie 6 (extra)", CdRelease = null, MpaaRating = Movie.MPAARating.G, Rating = 9, Premiere = new DateOnly(1980, 3, 15) },
        new Movie() {  Id = "007", Title = "Test movie 7 (extra)", CdRelease = null, MpaaRating = Movie.MPAARating.G, Rating = 2, Premiere = new DateOnly(2023, 3, 15) }
    }.AsQueryable();
}