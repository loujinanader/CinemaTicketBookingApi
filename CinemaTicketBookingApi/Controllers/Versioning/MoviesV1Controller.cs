using Asp.Versioning;
using CinemaTicketBookingApi.Services.Movies;
using Microsoft.AspNetCore.Mvc;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Controllers.Versioning
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/movies")]
    public class MoviesV1Controller : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesV1Controller(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAllMovies([FromQuery] MovieFilterParams filter)
        {
            var movies = _movieService.GetAllMoviesV1(filter);
            return Ok(movies);
        }

    }
}
