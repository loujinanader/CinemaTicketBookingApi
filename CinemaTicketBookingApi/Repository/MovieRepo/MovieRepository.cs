using CinemaTicketBookingApi.Data;
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.Repository.MovieRepo;
namespace CinemaTicketBookingApi.Repository.Classes
{
    public class MovieRepository : IMovieRepository
    {
        private readonly Movies_db _Db;
        public MovieRepository(Movies_db Db)
        {
            _Db = Db;
        }
        public IEnumerable<Movie> GetAllMovies(int pageId)
        {
            return _Db.Movies.Take(2).AsQueryable();
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

        public void DeleteMovie(int id) {
            var dmovie = _Db.Movies.FirstOrDefault(x => x.Id == id);
            _Db.Movies.Remove(dmovie);
            _Db.SaveChanges();
        }


    }
}
