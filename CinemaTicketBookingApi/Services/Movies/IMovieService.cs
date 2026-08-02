using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.Exceptions;
namespace CinemaTicketBookingApi.Services.Movies
{
    public interface IMovieService
    {
       public Movie CreateMovie(Movie movie);
       public void DeleteMovie(int movieId);
       public Movie GetMovieById(int id);
       public Movie UpdateMovie(Movie movie);
       public bool MovieTitleExists(string title);
       public IEnumerable<Movie> GetAllMovies(int pageNumber, int pageSize);
    }
}
