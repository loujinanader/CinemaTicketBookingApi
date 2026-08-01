using CinemaTicketBookingApi.Data;
using CinemaTicketBookingApi.DTOs;
using CinemaTicketBookingApi.Models;
namespace CinemaTicketBookingApi.Repository.Classes
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaContext _context;
        public MovieRepository(CinemaContext context)
        {
            _context = context;
        }
        public IEnumerable<Movie> GetAllMovies()
        {
            return
        }

        public Movie GetMovieById(int id)
        { 
        return }
        public Movie CreateMovie(CreateMovieDTO movie) { 
        return }
        public Movie UpdateMovie(int id, UpdateMovieDTO movie) {
            return 
        }
        public void DeleteMovie(int id) { }


    }
}
