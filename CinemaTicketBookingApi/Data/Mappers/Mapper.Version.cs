using CinemaTicketBookingApi.DTOs.versioning;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Data.Mappers
{
    public partial class Mapper
    {
       public MovieResponseV1DTO MapToMovieResponseV1(Movie movie) { 
            return new MovieResponseV1DTO {
                Id = movie.Id,
                title = movie.Title,
                AvailableSeats = movie.AvailableSeats
            };
        }
       public MovieResponseV2DTO MapToMovieResponseV2(Movie movie) {
            return new MovieResponseV2DTO {
                Id = movie.Id,
                Title = movie.Title,
                AvailableSeats = movie.AvailableSeats
            };
        }
    }
}
