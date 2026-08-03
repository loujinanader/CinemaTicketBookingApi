using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Services.Bookings
{
    public interface IBookingService
    {
        Booking CreateBooking(CreateBookingDTO dto);
        void CancelBooking(int id);
    }
}