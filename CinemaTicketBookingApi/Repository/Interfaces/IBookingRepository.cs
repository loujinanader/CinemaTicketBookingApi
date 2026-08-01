using CinemaTicketBookingApi.DTOs;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Repository.Interfaces
{
    public interface IBookingRepository
    {
        public Booking CreateBooking(CreateBookingDTO Booking);
        public void CancelBooking(CancelBookingDTO Booking);


    }
}
