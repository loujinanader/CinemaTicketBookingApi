using System;
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.DTOs;

namespace CinemaTicketBookingApi.Repository.MovieRepo
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> GetAllMovies(int pageNumber, int pageSize);
        public Movie GetMovieById(int id);
        public Movie CreateMovie(Movie movie);
        public Movie UpdateMovie(Movie movie);
        public void DeleteMovie(Movie movie);
    }
}
