using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Exceptions;
using CinemaTicketBookingApi.Exceptions.Movies;
using CinemaTicketBookingApi.Models;
namespace CinemaTicketBookingApi.Services.Bookings
{
    public  partial class BookingService
    {
        private void ValidateBeforeBooking(CreateBookingDTO booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));
            Movie movie = _movieRepository.GetMovieById(booking.MovieId);
            if (movie == null)
                throw new MovieNotFoundException(booking.MovieId);
            if (!movie.AvailableInCinema)
                throw new Exception("This movie is not available in the cinema.");
            if (booking.NumberOfTickets <= 0)
                throw new ArgumentException("Number of tickets must be greater than zero.");
            if (movie.AvailableSeats < booking.NumberOfTickets)
                throw new InsufficientSeatsException(
                    "There are not enough available seats.");
        }
        private void DecreaseAvailableSeats(Movie movie, int numberOfTickets)
        {
            movie.AvailableSeats -= numberOfTickets;
        }
        private void ValidateBeforeCancel()
        {
        }
    }
}
