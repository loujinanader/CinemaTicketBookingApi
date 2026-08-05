using Asp.Versioning;
using CinemaTicketBookingApi.Services.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBookingApi.Controllers.Versioning
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/movies")]
    public class MoviesV2Controller : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesV2Controller(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAllMovies(int pageNumber = 1, int pageSize = 2)
        {
            var movies = _movieService.GetAllMoviesV2(pageNumber, pageSize);
            return Ok(movies);
        }
    }
}
