using CinemaTicketBookingApi.Data.DataBase;
using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBookingApi.Repository.BookingRepo
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Movies_db _db;
        public BookingRepository(Movies_db db)
        {
            _db = db;
        }
        public Booking Add(Booking booking)
        {
             _db.Bookings.Add(booking);
             _db.SaveChanges();
            return booking;
        }
        public void Delete(Booking booking) {
            _db.Bookings.Remove(booking);
            _db.SaveChanges();
        }
        public IEnumerable<Booking> GetAll()
        {
            return _db.Bookings
                      .Include(b => b.Movie)
                      .ToList();
        }
        public Booking GetById(int id)
        {
            return _db.Bookings
                    .Include(b => b.Movie)
                    .FirstOrDefault(b => b.Id == id);
        }
        public bool HasBookingsForMovie(int movieId)     
            => _db.Bookings.Any(b => b.MovieId == movieId);
    }
}