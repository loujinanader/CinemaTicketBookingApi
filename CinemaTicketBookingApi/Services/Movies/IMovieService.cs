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
        public PagedResult<MovieResponseDTO> GetAllMovies(MovieFilterParams filter);

        public IEnumerable<MovieResponseV1DTO> GetAllMoviesV1(MovieFilterParams filter);

        public IEnumerable<MovieResponseV2DTO> GetAllMoviesV2(MovieFilterParams filter);
    }
}
