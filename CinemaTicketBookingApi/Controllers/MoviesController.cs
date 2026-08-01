using CinemaTicketBookingApi.Services.Interfaces;
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
        //[HttpGet]



        //create
        //[HttpPost]


        //Delete
        //[HttpDelete]


        //Update
        //[HttpPut]




    }
}
