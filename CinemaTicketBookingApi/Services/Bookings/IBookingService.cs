using CinemaTicketBookingApi.DTOs.Booking;
namespace CinemaTicketBookingApi.Services.Bookings
{
    public interface IBookingService
    {
      public BookingResponseDto CreateBooking(CreateBookingDTO dto);
       public void CancelBooking(int id);
        public IEnumerable<BookingResponseDto> GetAllBookings(int pageNumber, int pageSize);
        public BookingResponseDto GetBookingById(int id);
    }
}
