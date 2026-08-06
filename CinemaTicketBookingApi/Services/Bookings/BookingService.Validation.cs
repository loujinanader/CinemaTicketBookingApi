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
            if (string.IsNullOrWhiteSpace(booking.CustomerEmail))
                throw new ArgumentException("Customer email is required.");
            if (!new System.ComponentModel.DataAnnotations.EmailAddressAttribute()
                    .IsValid(booking.CustomerEmail))
            {
                throw new ArgumentException("Invalid email format.");
            }
            if (string.IsNullOrWhiteSpace(booking.CustomerName))
                throw new ArgumentException("Customer name is required.");
            if (string.IsNullOrWhiteSpace(booking.MovieName))
                throw new ArgumentException("Movie name is required.");
            return movie;
        }
        private void DecreaseAvailableSeats(Movie movie, int numberOfTickets)
        {
             movie.AvailableSeats -= numberOfTickets;
            if (movie.AvailableSeats == 0)
                  movie.AvailableInCinema = false;
        }
         private Booking ValidateBeforeCancel(int bookingId)
         {
            Booking booking = _repository.GetById(bookingId);

            if (booking == null)
                throw new BookingNotFoundException(
                    $"Booking with id {bookingId} was not found.");

            return booking;
         }
        private void IncreaseAvailableSeats(Movie movie, int numberOfTickets)
        { 
                   movie.AvailableSeats += numberOfTickets;
                   movie.AvailableInCinema = true;

        }

    }
}
