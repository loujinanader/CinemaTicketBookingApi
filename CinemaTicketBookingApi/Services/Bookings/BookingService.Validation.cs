using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Exceptions.booking;
using CinemaTicketBookingApi.Exceptions.Movies;
using CinemaTicketBookingApi.Models;
namespace CinemaTicketBookingApi.Services.Bookings
{
    public  partial class BookingService
    {
        private Movie ValidateBeforeBooking(CreateBookingDTO booking)
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
            if (!movie.AvailableInCinema)
                throw new MovieNotAvailableException(movie.Id);
            return movie;
        }
        private void DecreaseAvailableSeats(Movie movie, int numberOfTickets)
        {
            if (movie.AvailableSeats > numberOfTickets)
                throw new InsufficientSeatsException("There are not enough available seats.");
            movie.AvailableSeats -= numberOfTickets;
        }
        private Movie ValidateBeforeCancel(int id)
        {
            Movie movie = _movieRepository.GetMovieById(id);
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            return movie;
        }
        private void IncreaseAvailableSeats(Movie movie, int numberOfTickets)
        {
           
            if (numberOfTickets <= 0)
                throw new ArgumentException("Number of tickets must be greater than zero.");
            movie.AvailableSeats += numberOfTickets;
        }
    }
}
