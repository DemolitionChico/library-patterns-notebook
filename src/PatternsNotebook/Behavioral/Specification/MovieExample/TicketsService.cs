using PatternsNotebook.Behavioral.Specification.MovieExample.Database;
using PatternsNotebook.Behavioral.Specification.MovieExample.Specifications;

namespace PatternsNotebook.Behavioral.Specification.MovieExample;

public class TicketsService
{
    private readonly MovieRepository _repository = new MovieRepository(new MovieDbContext());

    private readonly Specification<Movie> forChildrenSpecification = new MovieForKidsSpecification();
    
    public void BuyTicketForAdult(string movieId)
    {
        var movie = _repository.GetMovieById(movieId);
        Console.WriteLine($"You have bought one ticket for {movie.Title}");
    }

    public void BuyTicketForChild(string movieId)
    {
        var movie = _repository.GetMovieById(movieId);
        if (forChildrenSpecification.IsSatisfiedBy(movie))
        {
            Console.WriteLine($"You have bought one ticket for {movie.Title}");
        }
        else
        {
            Console.WriteLine($"Movie {movie.Title} is not for children");
        }
    }
}