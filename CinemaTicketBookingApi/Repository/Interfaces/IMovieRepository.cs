using System;
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.DTOs;

namespace CinemaTicketBookingApi.Repository
{
    public interface IMovieRepository
    {
        public IEnumerable <Movie> GetAllMovies();
        public Movie GetMovieById(int id);
        public Movie CreateMovie(CreateMovieDTO movie);
        public Movie UpdateMovie(int id, UpdateMovieDTO movie);
        public void DeleteMovie(int id);
    }
}
