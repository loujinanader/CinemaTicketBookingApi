using CinemaTicketBookingApi.Data.Mappers;
using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.Repository.BookingRepo;
using CinemaTicketBookingApi.Repository.MovieRepo;

namespace CinemaTicketBookingApi.Services.Bookings
{
    public partial class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IMapper _mapper;
        public BookingService(IBookingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Booking CreateBooking(CreateBookingDTO booking)
        {
            ValidateBeforeBooking(booking);
           throw new NotImplementedException();
        }
        public void CancelBooking(int id)
        {
            // Implementation for canceling a booking
        }   
    }
}