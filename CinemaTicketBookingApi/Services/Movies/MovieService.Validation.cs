using CinemaTicketBookingApi.Exceptions.Movies;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Services.Movies
{
    public partial class MovieService
    {
        private void ValidateMovieBeforeDelete(Movie movieToBeDeleted, int movieId)
        {
            if (movieToBeDeleted == null)
                throw new MovieNotFoundException(movieId);
        }
    }
}
