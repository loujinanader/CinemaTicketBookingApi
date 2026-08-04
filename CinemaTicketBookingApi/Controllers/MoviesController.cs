using CinemaTicketBookingApi.DTOs.Movie;
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
        [HttpGet]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movieService.GetMovieById(id);
            return Ok(movie);
        }
        [HttpPost]
        public IActionResult CreateMovie(CreateMovieDTO dTO)
        {
            var createdMovie = _movieService.CreateMovie(dTO);
            return Created("", createdMovie);
        }
        [HttpDelete]
        public IActionResult DeleteMovie(int movieId)
        {
            _movieService.DeleteMovie(movieId);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateMovie(UpdateMovieDTO dTO)
        {
            var updatedMovie = _movieService.UpdateMovie(dTO);
            return Ok(updatedMovie);

        }
    }
}
