using CinemaTicketBookingApi.Models;
namespace CinemaTicketBookingApi.Repository.MovieRepo
{
    public interface IMovieRepository
    {
        public PagedResult<Movie> GetAllMovies(MovieFilterParams filter);
        public Movie GetMovieById(int id);
        public Movie CreateMovie(Movie movie);
        public Movie UpdateMovie(Movie movie);
        public void DeleteMovie(Movie movie);
        public bool MovieTitleExists(string title);
        public Movie GetMovieByTitle(string title);
        public bool MovieHasBookings(int movieId);
    }
}
