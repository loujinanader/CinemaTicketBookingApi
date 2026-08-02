
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.DTOs;

namespace CinemaTicketBookingApi.Services.Interfaces
{
    public interface IBookingService
    {
       public void CancelBooking(int id);
      public Booking CreateBooking(CreateBookingDTO booking);
      public Booking GetAllBookings(int pageId);
       public Booking GetBookingdetails(int id);
    }
}
