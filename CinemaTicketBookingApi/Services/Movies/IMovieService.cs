using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.Exceptions;
using CinemaTicketBookingApi.DTOs.Movie;
namespace CinemaTicketBookingApi.Services.Movies
{
    public interface IMovieService
    {
       public MovieResponseDTO CreateMovie(CreateMovieDTO dTO);
       public void DeleteMovie(int movieId);
       public Movie GetMovieById(int id);
       public Movie UpdateMovie(Movie movie);
       public bool MovieTitleExists(string title);
       public IEnumerable<Movie> GetAllMovies(int pageNumber, int pageSize);
    }
}
