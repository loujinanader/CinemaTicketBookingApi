using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Repository.BookingRepo
{
    public interface IBookingRepository
    {
        public Booking Add(Booking booking);
       public Booking GetById(int id);
       public IEnumerable<Booking> GetAll();
       public void Delete(Booking booking);
    }
}
