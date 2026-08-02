using CinemaTicketBookingApi.Data;
using CinemaTicketBookingApi.DTOs;
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.Repository.Interfaces;

namespace CinemaTicketBookingApi.Repository.Classes
{
    public class BookingRepository : IBookingRepository
    {
        private readonly CinemaContext _db;
        public BookingRepository(CinemaContext context)
        {
            _db = context;
        }
        public Booking CreateBooking(CreateBookingDTO Booking)
        {
            _db.Bookings.Add(Booking);

            _db.SaveChanges();
            return Booking;
        }
        public  void CancelBooking(CancelBookingDTO Booking) { }
    }
}
