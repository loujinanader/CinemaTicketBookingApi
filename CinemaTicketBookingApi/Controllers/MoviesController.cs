using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBookingApi.Controllers
{
    public class MoviesController : Controller
    {



        public IActionResult Index()
        {
            return View();
        }
    }
}
