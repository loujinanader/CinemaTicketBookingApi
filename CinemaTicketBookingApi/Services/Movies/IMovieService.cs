using CinemaTicketBookingApi.DTOs.Movie;
using CinemaTicketBookingApi.DTOs.versioning;
using CinemaTicketBookingApi.Models;
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
       public IEnumerable<MovieResponseV1DTO> GetAllMoviesV1(int pageNumber, int pageSize);

        public IEnumerable<MovieResponseV2DTO> GetAllMoviesV2(int pageNumber, int pageSize);
    }
}
