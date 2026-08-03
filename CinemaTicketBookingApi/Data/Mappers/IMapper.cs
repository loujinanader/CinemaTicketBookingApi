using CinemaTicketBookingApi.DTOs.Movie;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Data.Mappers
{
    public interface IMapper
    {
        Movie MapToMovie(CreateMovieDTO dTO);
        MovieResponseDTO MapToMovieResponseDTO(Movie createdMoive);

        Movie MapToMovie(UpdateMovieDTO dTO);
    }
}