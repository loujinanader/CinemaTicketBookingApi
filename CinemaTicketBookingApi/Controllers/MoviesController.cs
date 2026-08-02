using Microsoft.AspNetCore.Mvc;
using CinemaTicketBookingApi.Repository;
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.Services.Movies;

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
            var movie = _movieService.GetMovieByIdAsync(id);
            return Ok(movie);
        }



        //create
        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {
            var createdMovie = _movieService.CreateMovieAsync(movie);
            return Ok(createdMovie);
        }


        //Delete
        [HttpDelete]
        public IActionResult DeleteMovie(int id)
        {
            _movieService.DeleteMovieAsync(id);
            return Ok();
        }


        //Update
        [HttpPut]

        public IActionResult UpdateMovie(Movie movie)
        {
            var updatedMovie = _movieService.UpdateMovieAsync(movie);
            return Ok(updatedMovie);



        }
    }
}
