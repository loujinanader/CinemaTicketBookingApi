using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.DTOs.Booking;
namespace CinemaTicketBookingApi.Services.Bookings
{
    public interface IBookingService
    {
       public void CancelBooking(int id);
      public Booking CreateBooking(CreateBookingDTO booking);
    }
}
