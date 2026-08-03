
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.DTOs.Booking;

namespace CinemaTicketBookingApi.Services.Interfaces
{
    public interface IBookingService
    {
       public void CancelBooking(int id);
      public Booking CreateBooking(CreateBookingDTO booking);
      //public IEnumerable<BookingDto> GetAllBookings(int pageId);
      // public BookingDto GetBookingdetails(int id);
    }
}
