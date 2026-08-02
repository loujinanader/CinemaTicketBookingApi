using System;
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.DTOs;

namespace CinemaTicketBookingApi.Repository.MovieRepo
{
    public interface IMovieRepository
    {
        public IEnumerable <Movie> GetAllMovies(int pageId);
        public Movie GetMovieById(int id);
        public Movie CreateMovie(Movie movie);
        public Movie UpdateMovie(Movie movie);
        public void DeleteMovie(int id);
    }
}
