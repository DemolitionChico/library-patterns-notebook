using System.Linq.Expressions;

namespace PatternsNotebook.Behavioral.Specification.MovieExample.Specifications;

public class MovieForKidsSpecification : Specification<Movie>
{
    public override Expression<Func<Movie, bool>> ToExpression()
    {
        return movie => movie.MpaaRating <= Movie.MPAARating.PG;
    }
}