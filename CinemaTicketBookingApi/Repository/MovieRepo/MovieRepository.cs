using CinemaTicketBookingApi.Data;
using CinemaTicketBookingApi.Models;
namespace CinemaTicketBookingApi.Repository.MovieRepo
{
    public class MovieRepository : IMovieRepository
    {
        private readonly Movies_db _Db;
        public MovieRepository(Movies_db Db)
        {
            _Db = Db;
        }
        public IEnumerable<Movie> GetAllMovies(int pageNumber, int pageSize)
        {
            return _Db.Movies
                      .Skip((pageNumber - 1) * pageSize)
                      .Take(pageSize)
                      .ToList();
        }

        public Movie GetMovieById(int id) 
            => _Db.Movies.FirstOrDefault(m => m.Id == id);
        
        public Movie CreateMovie(Movie movie)
        {
            _Db.Movies.Add(movie);
            _Db.SaveChanges();
            return movie;
        } 
           
        public Movie UpdateMovie(Movie movie)
        {
            _Db.Movies.Update(movie);
            _Db.SaveChanges();
            return movie;
        }

        public void DeleteMovie(Movie movie) {
            _Db.Movies.Remove(movie);
            _Db.SaveChanges();
        }

    }
}
