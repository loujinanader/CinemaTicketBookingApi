using CinemaTicketBookingApi.DTOs.Movie;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Data.Mappers
{
    public partial class Mapper : IMapper
    {
        public Movie MapToMovie(CreateMovieDTO dTO)
        {
            return new Movie
            {
                Title = dTO.Title,
                ReleaseYear = dTO.ReleaseYear,
                AvailableInCinema = true,
                AvailableSeats = dTO.AvailableSeats,
                Duration = dTO.Duration,
                Genre = dTO.Genre
            };
        }
        public  MovieResponseDTO MapToMovieResponseDTO(Movie createdMoive)
        {
            return new MovieResponseDTO
            {
                ID = createdMoive.Id,
                Title = createdMoive.Title,
                ReleaseYear = createdMoive.ReleaseYear,
                AvailableSeats = createdMoive.AvailableSeats,
                Duration = createdMoive.Duration,
                Genre = createdMoive.Genre

            };
        }
        public Movie MapToMovie(UpdateMovieDTO dTO)
        {
            return new Movie
            {
                Id = dTO.Id,
                Title = dTO.Title,
                ReleaseYear = dTO.ReleaseYear,
                AvailableInCinema = dTO.AvailableInCinema,
                AvailableSeats = dTO.AvailableSeats,
                Duration = dTO.Duration,
                Genre = dTO.Genre
            };
        }
       
    }
}
