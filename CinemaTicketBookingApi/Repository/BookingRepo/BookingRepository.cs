using CinemaTicketBookingApi.Data.DataBase;
using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Repository.BookingRepo
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Movies_db _db;
        public BookingRepository(Movies_db context)
        {
            _db = context;
        }
        public Booking CreateBooking(CreateBookingDTO bookingDto)
        {
            if (bookingDto == null) throw new ArgumentNullException(nameof(bookingDto));

            var booking = new Booking
            {
                MovieId = bookingDto.MovieId,
                CustomerName = bookingDto.CustomerName,
                CustomerEmail = bookingDto.CustomerEmail,
                BookingDate = bookingDto.BookingDate,
                NumberOfTickets = bookingDto.NumberOfTickets
            };

            _db.Bookings.Add(booking);
            _db.SaveChanges();
            return booking;
        }
        public  void CancelBooking(CancelBookingDTO Booking) {
          _db.Bookings.Remove(_db.Bookings.FirstOrDefault(b => b.Id == Booking.Id));
        }
    }
}
