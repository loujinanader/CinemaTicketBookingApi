using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBookingApi.Controllers.Versioning
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/movies")]
    public class MoviesV2Controller : ControllerBase
    {
      
    }
}
