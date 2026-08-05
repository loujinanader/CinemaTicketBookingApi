using Asp.Versioning;
using CinemaTicketBookingApi.Services.Movies;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllMovies(int pageNumber = 1, int pageSize = 2)
        {
            var movies = _movieService.GetAllMoviesV1(pageNumber, pageSize);
            return Ok(movies);
        }

    }
}
