using System.Linq.Expressions;

namespace PatternsNotebook.Behavioral.Specification.MovieExample.Specifications;

// This class shows an example of parameterized specification
class MovieTitleContainsSpecification : Specification<Movie>
{
    private readonly string _titleQuery;
    public MovieTitleContainsSpecification(string titleQuery)
    {
        _titleQuery = titleQuery;
    }
    public override Expression<Func<Movie, bool>> ToExpression()
    {
        return movie => movie.Title.Contains(_titleQuery);
    }
}