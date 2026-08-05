using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.DTOs.Movie;
using CinemaTicketBookingApi.DTOs.versioning;
using CinemaTicketBookingApi.Models;
namespace CinemaTicketBookingApi.Data.Mappers
{
    public interface IMapper
    {
        public Movie MapToMovie(CreateMovieDTO dTO);
        public MovieResponseDTO MapToMovieResponseDTO(Movie movie);
        public Movie MapToMovie(UpdateMovieDTO dTO);
        public void MapToExistingMovie(UpdateMovieDTO dto, Movie movie);
        public Booking MapToBooking(CreateBookingDTO dto);
        public BookingResponseDto MaptoBookingResponse(Booking booking);
        public MovieResponseV1DTO MapToMovieResponseV1(Movie movie);
        public MovieResponseV2DTO MapToMovieResponseV2(Movie movie);
    }
}