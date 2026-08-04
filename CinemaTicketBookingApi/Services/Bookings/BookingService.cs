using CinemaTicketBookingApi.Data.Mappers;
using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.Repository.BookingRepo;
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
           Booking BookingToCreate =_mapper.MapToBooking(booking);
            return BookingToCreate;
        }
        public void CancelBooking(int id)
        {
            Booking bookingToBeCanceled = _repository.GetById(id);
            //ValidateBookingBeforeCancel(bookingToBeCanceled, id);
            _repository.Delete(bookingToBeCanceled);
        }   
    }
}