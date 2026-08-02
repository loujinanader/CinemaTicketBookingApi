using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Repository.BookingRepo
{
    public interface IBookingRepository
    {
        public Booking CreateBooking(CreateBookingDTO Booking);
        public void CancelBooking(CancelBookingDTO Booking);


    }
}
