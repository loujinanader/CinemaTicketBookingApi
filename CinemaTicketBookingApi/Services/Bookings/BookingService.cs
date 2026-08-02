using CinemaTicketBookingApi.DTOs;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Services.Bookings
{
    public class BookingService : IBookingService
    {
        public readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public void CancelBooking(int id)
        {

        }
        public Booking CreateBooking(CreateBookingDTO booking)
        {
            if (booking == null) {
                throw new ArgumentNullException(nameof(booking));
            }
        }   return 

}   }