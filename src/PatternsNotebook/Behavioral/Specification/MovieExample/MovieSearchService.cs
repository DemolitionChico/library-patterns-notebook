using PatternsNotebook.Behavioral.Specification.MovieExample.Database;
using PatternsNotebook.Behavioral.Specification.MovieExample.Specifications;

namespace PatternsNotebook.Behavioral.Specification.MovieExample;

public class MovieSearchService
{
    private readonly MovieRepository _repository = new MovieRepository(new MovieDbContext()); 
        
    public IEnumerable<Movie> GetMovies(MovieFilter filter)
    {
        Specification<Movie> moviesSpecification = Specification<Movie>.All;
        if (filter.IsNotForChildren)
        {
            moviesSpecification = moviesSpecification.And(new MovieForKidsSpecification().Not());
        }

        if (filter.IsOnCd)
        {
            moviesSpecification = moviesSpecification.And(new MovieOnCdSpecification());
        }

        if (!string.IsNullOrEmpty(filter.OrTitleContains))
        {
            moviesSpecification = moviesSpecification.Or(new MovieTitleContainsSpecification(filter.OrTitleContains));
        }

        // The rating part of the filtering is not a specification.
        // The purpose of that is to show that specification can be easily combined with simple expressions
        return _repository.GetMovies(moviesSpecification, filter.RatingOver);
    }
}

public struct MovieFilter
{
    public bool IsNotForChildren { get; init; }
    public bool IsOnCd { get; init; }
    public string OrTitleContains { get; init; }
    public double RatingOver { get; set; }
}