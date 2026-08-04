using CinemaTicketBookingApi.Data.Mappers;
using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.Repository.BookingRepo;
using CinemaTicketBookingApi.Repository.MovieRepo;
using Microsoft.AspNetCore.Http.HttpResults;
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
            DecreaseAvailableSeats(movie, booking.NumberOfTickets);
            _movieRepository.UpdateMovie(movie);
            Booking createdBooking = _repository.Add(BookingToCreate);
            if (createdBooking == null) throw new InvalidOperationException("Repository.Add returned null.");
            // Ensure entity is persisted so GetById can find it
            _dbContext.SaveChanges();
            var createdId = createdBooking.Id;
            createdBooking = _repository.GetById(createdBooking.Id);
            BookingDtos response = _mapper.MapToBookingDto(createdBooking);
            if (response == null) throw new InvalidOperationException($"Booking not found after creation. Id: {createdId}");
            return response;","explanation":"Per user choice, call SaveChanges in the service after calling repository.Add so the subsequent GetById can find the persisted booking."}{
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