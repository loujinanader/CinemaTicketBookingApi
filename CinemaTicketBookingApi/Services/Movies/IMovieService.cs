using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Services.Movies
{
    public interface IMovieService
    {
        object CreateMovieAsync(Movie movie);
        void DeleteMovieAsync(int id);
        Task GetMovieByIdAsync(int id);
        object UpdateMovieAsync(Movie movie);
    }
}
