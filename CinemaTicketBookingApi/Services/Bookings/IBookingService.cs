
using CinemaTicketBookingApi.DTOs;

namespace CinemaTicketBookingApi.Services.Interfaces
{
    public interface IBookingService
    {
        void CancelBooking(int id);
        object CreateBooking(CreateBookingDTO booking);
        object GetAllBookings(int pageId);
        object GetBookingdetails(int id);
    }
}
