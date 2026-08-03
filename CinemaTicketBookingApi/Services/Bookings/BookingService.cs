using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Services.Bookings
{
    public class BookingService : IBookingService
    {
        public Booking CreateBooking(CreateBookingDTO booking)
        {
            throw new NotImplementedException();
        }
        public void CancelBooking(int id)
        {
            // Implementation for canceling a booking
        }   
    }
}