using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBookingApi.Controllers.Versioning
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/movies")]
    public class MoviesV1Controller : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            // Implementation for getting movie by ID
            return Ok();
        }
    }
}
