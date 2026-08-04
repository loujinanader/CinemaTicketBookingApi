using CinemaTicketBookingApi.Data.DataBase;
using CinemaTicketBookingApi.Models;
namespace CinemaTicketBookingApi.Repository.MovieRepo
{
    public class MovieRepository : IMovieRepository
    {
        private readonly Movies_db _db;
        public MovieRepository(Movies_db db)
        {
            _db = db;
        }
        public IEnumerable<Movie> GetAllMovies(int pageNumber, int pageSize)
        {
            return _db.Movies
                      .Skip((pageNumber - 1) * pageSize)
                      .Take(pageSize)
                      .ToList();
        }
        public Movie GetMovieById(int id) 
            => _db.Movies.FirstOrDefault(m => m.Id == id);
        public Movie CreateMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return movie;
        } 
        public Movie UpdateMovie(Movie movie)
        {
            _db.SaveChanges();
            return movie;
        }

        public void DeleteMovie(Movie movie) {
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }
        public bool MovieTitleExists(string title)
            => _db.Movies.Any(m => m.Title == title);
        public Movie GetMovieByTitle(string title)
           => _db.Movies.FirstOrDefault(m => m.Title == title);
    }
}
