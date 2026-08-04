using CinemaTicketBookingApi.DTOs.Booking;
namespace CinemaTicketBookingApi.Services.Bookings
{
    public interface IBookingService
    {
      public BookingDtos CreateBooking(CreateBookingDTO dto);
       public void CancelBooking(int id);
        public IEnumerable<BookingDtos> GetAllBookings(int pageNumber, int pageSize);
        public BookingDtos GetBookingById(int id);
    }
}
