using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.DTOs.Movie;
namespace CinemaTicketBookingApi.Services.Movies
{
    public interface IMovieService
    {
       public MovieResponseDTO CreateMovie(CreateMovieDTO dTO);
       public void DeleteMovie(int movieId);
       public Movie GetMovieById(int id);
        public MovieResponseDTO UpdateMovie(UpdateMovieDTO dTO);
       public bool MovieTitleExists(string title);
        public IEnumerable<MovieResponseDTO> GetAllMovies(int pageNumber, int pageSize);
    }
}
