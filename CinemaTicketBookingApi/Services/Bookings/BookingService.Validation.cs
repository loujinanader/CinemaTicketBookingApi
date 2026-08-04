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
            if (booking.NumberOfTickets <= 0)
                throw new ArgumentException("Number of tickets must be greater than zero.");
            Movie movie = _movieRepository.GetMovieByTitle(booking.MovieName);
            if (movie == null)
                throw new MovieNotFoundException(booking.MovieName);
            if (!movie.AvailableInCinema)
                throw new MovieNotAvailableException(movie.Id);
            if (movie.AvailableSeats < booking.NumberOfTickets)
                throw new InsufficientSeatsException("There are not enough available seats.");
            return movie;
        }
        private void DecreaseAvailableSeats(Movie movie, int numberOfTickets)
              =>    movie.AvailableSeats -= numberOfTickets;
         private Booking ValidateBeforeCancel(int bookingId)
         {
            Booking booking = _repository.GetById(bookingId);

            if (booking == null)
                throw new BookingNotFoundException(
                    $"Booking with id {bookingId} was not found.");

            return booking;
         }
        private void IncreaseAvailableSeats(Movie movie, int numberOfTickets)
                  => movie.AvailableSeats += numberOfTickets;


    }
}
