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
        private readonly IMovieRepository _movieRepository;
        public BookingService(IBookingRepository repository, IMapper mapper,IMovieRepository movieRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public BookingDtos CreateBooking(CreateBookingDTO booking)
        {
           Movie movie = ValidateBeforeBooking(booking);
           Booking BookingToCreate =_mapper.MapToBooking(booking);
            BookingDtos response = _mapper.MapToBookingDto(BookingToCreate);
            DecreaseAvailableSeats(movie,booking.NumberOfTickets);
            _repository.UpdateMovie(movie);
            return response;
        }
        public void CancelBooking(int id)
        {
            Booking bookingToBeCanceled = _repository.GetById(id);
            //ValidateBookingBeforeCancel(bookingToBeCanceled, id);
            _repository.Delete(bookingToBeCanceled);
        }   
        public IEnumerable<BookingDtos> GetAll(int pageNumber, int pageSize)
        {
            var bookings = _repository.GetAll();
            var paged = bookings
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            return paged.Select(b => _mapper.MapToBookingDto(b));
        }
        public BookingDtos GetBookingById(int id)
        {
            var booking = _repository.GetById(id);
            return _mapper.MapToBookingDto(booking);
        }
    }
}