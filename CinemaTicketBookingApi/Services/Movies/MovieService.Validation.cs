using CinemaTicketBookingApi.DTOs.Movie;
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
        private void ValidateBeforeCreate(CreateMovieDTO movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (_repository.MovieTitleExists(movie.Title))
                throw new MovieAlreadyExistsException("A movie with this title already exists.");
        }
        public void ValidateMovieBeforeUpdate(UpdateMovieDTO movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
        }


    }
}
