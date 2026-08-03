using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Exceptions;

namespace CinemaTicketBookingApi.Services.Bookings
{
    public  partial class BookingService
    {
        private void ValidateBeforeBooking(CreateBookingDTO booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));
        }
    }
}
