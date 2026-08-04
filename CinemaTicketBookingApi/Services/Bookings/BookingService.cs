using CinemaTicketBookingApi.Data.Mappers;
using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Exceptions.booking;
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
        public BookingResponseDto CreateBooking(CreateBookingDTO booking)
        {
            Movie movie = ValidateBeforeBooking(booking);  
           Booking BookingToCreate =_mapper.MapToBooking(booking);
            BookingToCreate.MovieId = movie.Id;
            DecreaseAvailableSeats(movie, booking.NumberOfTickets);
            _movieRepository.UpdateMovie(movie);
            Booking createdBooking = _repository.Add(BookingToCreate);
            if (createdBooking == null)
                throw new InvalidOperationException("Failed to create booking.");
            createdBooking = _repository.GetById(createdBooking.Id);
           return _mapper.MaptoBookingResponse(createdBooking);
        }
        public void CancelBooking(int id)
        {
          Booking booking = ValidateBeforeCancel(id);
            Movie movie = _movieRepository.GetMovieById(booking.MovieId);
            IncreaseAvailableSeats(movie, booking.NumberOfTickets);
            _movieRepository.UpdateMovie(movie);
            _repository.Delete(booking);
        }
        public IEnumerable<BookingResponseDto> GetAllBookings(int pageNumber, int pageSize)
        {
            var bookings = _repository.GetAll();

            return bookings
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(b => _mapper.MaptoBookingResponse(b));
        }
        public BookingResponseDto GetBookingById(int id)
        {
            var booking = _repository.GetById(id);
            if (booking == null)
                throw new BookingNotFoundException(
                    $"Booking with id {id} was not found.");
            return _mapper.MaptoBookingResponse(booking);
        }
    }
}