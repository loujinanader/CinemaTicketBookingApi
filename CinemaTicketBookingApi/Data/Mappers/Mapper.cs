using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Models;
namespace CinemaTicketBookingApi.Data.Mappers
{
    public partial class Mapper : IMapper
    {
        public Booking MapToBooking(CreateBookingDTO dto)
        {
            return new Booking
            {
                CustomerName = dto.CustomerName,
                CustomerEmail = dto.CustomerEmail,
                BookingDate = dto.BookingDate,
                NumberOfTickets = dto.NumberOfTickets,
                MovieId = dto.MovieId
            };
        }
        public BookingDtos MapToBookingDto(Booking booking)
        {
            if (booking == null) throw new ArgumentNullException(nameof(booking));
            if (booking.Movie == null) throw new InvalidOperationException("Booking.Movie is null.");
            return new BookingDtos
            { 
                Id = booking.Id,
                MovieId = booking.MovieId,
                CustomerName = booking.CustomerName,
                CustomerEmail = booking.CustomerEmail,
                BookingDate = booking.BookingDate,
                NumberOfTickets = booking.NumberOfTickets,
                MovieName = booking.Movie.Title
            };
        }
    }
}
