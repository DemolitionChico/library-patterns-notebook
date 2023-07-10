using System.Linq.Expressions;

namespace PatternsNotebook.Behavioral.Specification.MovieExample.Specifications;

public class MovieOnCdSpecification : Specification<Movie>
{
    public override Expression<Func<Movie, bool>> ToExpression()
    {
        return movie => movie.CdRelease != null && DateOnly.FromDateTime(DateTime.Now) > movie.CdRelease;
    }
}