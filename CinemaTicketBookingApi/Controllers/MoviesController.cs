using CinemaTicketBookingApi.DTOs;
using CinemaTicketBookingApi.DTOs.Movie;
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.Repository;
using CinemaTicketBookingApi.Services.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        //Read
        [HttpGet]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movieService.GetMovieById(id);
            return Ok(movie);
        }



        //create
        [HttpPost]
        public IActionResult CreateMovie(CreateMovieDTO dTO)
        {
            var createdMovie = _movieService.CreateMovie(dTO);
            return Created("", createdMovie);
        }


        //Delete
        [HttpDelete]
        public IActionResult DeleteMovie(int movieId)
        {
            _movieService.DeleteMovie(movieId);
            return Ok();
        }


        //Update
        [HttpPut]

        public IActionResult UpdateMovie(Movie movie)
        {
            var updatedMovie = _movieService.UpdateMovie(movie);
            return Ok(updatedMovie);

        }
    }
}
