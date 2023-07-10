using PatternsNotebook.Behavioral.Specification.MovieExample.Database;
using PatternsNotebook.Behavioral.Specification.MovieExample.Specifications;

namespace PatternsNotebook.Behavioral.Specification.MovieExample;

public class MovieRepository
{
    private readonly MovieDbContext _dbContext;

    public MovieRepository(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IReadOnlyList<Movie> GetMovies(Specification<Movie> specification, double minimalRating = 0)
    {
        return _dbContext
            .Movies
            .Where(specification.ToExpression())
            // Minimal rating filtered separately is an example of criteria not always having to be a specification.
            // If business logic for such criteria is not used elsewhere, there is no need to make it a specification, 
            // as specifications can easily be combined with simple filers
            .Where(x => x.Rating >= minimalRating)
            .ToList();
    }

    public Movie GetMovieById(string id)
    {
        return _dbContext.Movies.First(x => x.Id == id);
    }
}