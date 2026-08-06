using CinemaTicketBookingApi.DTOs.Movie;
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.Services.Movies;
using Microsoft.AspNetCore.Mvc;
namespace CinemaTicketBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movieService.GetMovieById(id);
            return Ok(movie);
        }
        [HttpPost]
        public IActionResult CreateMovie(CreateMovieDTO dTO)
        {
            var createdMovie = _movieService.CreateMovie(dTO);
            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.ID }, createdMovie);
        }
        [HttpDelete]
        public IActionResult DeleteMovie(int movieId)
        {
            _movieService.DeleteMovie(movieId);
            return Ok();
        }
        [HttpPatch("{id}/available-seats")]
        public IActionResult UpdateAvailableSeats(int id, UpdateAvailableSeatsDTO dto)
        {
            var movie = _movieService.UpdateAvailableSeats(id, dto);
            return Ok(movie);
        }
        [HttpGet]
        public IActionResult GetAllMovies([FromQuery] MovieFilterParams filter)
        {
            var movies = _movieService.GetAllMovies(filter);

            return Ok(movies);
        }
    }
}
