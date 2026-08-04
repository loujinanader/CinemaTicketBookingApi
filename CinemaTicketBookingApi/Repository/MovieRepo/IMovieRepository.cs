using CinemaTicketBookingApi.Models;
namespace CinemaTicketBookingApi.Repository.MovieRepo
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> GetAllMovies(int pageNumber, int pageSize);
        public Movie GetMovieById(int id);
        public Movie CreateMovie(Movie movie);
        public Movie UpdateMovie(Movie movie);
        public void DeleteMovie(Movie movie);
        public bool MovieTitleExists(string title);
        public Movie GetMovieByTitle(string title);
    }
}
