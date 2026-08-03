using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.DTOs.Movie;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Data.Mappers
{
    public interface IMapper
    {
        Movie MapToMovie(CreateMovieDTO dTO);
        MovieResponseDTO MapToMovieResponseDTO(Movie createdMoive);

        Movie MapToMovie(UpdateMovieDTO dTO);
        void MapToExistingMovie(UpdateMovieDTO dto, Movie movie);
        public Booking MapToBooking(CreateBookingDTO dto);
        public BookingDtos MapToBookingDto(Booking booking);
    }
}