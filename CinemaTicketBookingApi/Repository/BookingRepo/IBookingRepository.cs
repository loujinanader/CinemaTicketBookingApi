using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Repository.BookingRepo
{
    public interface IBookingRepository
    {
        public Booking Add(Booking booking);
        public void Delete(Booking booking);
        public IEnumerable<Booking> GetAll();
        public Booking GetById(int id);
        public bool HasBookingsForMovie(int movieId);
    }
}
   