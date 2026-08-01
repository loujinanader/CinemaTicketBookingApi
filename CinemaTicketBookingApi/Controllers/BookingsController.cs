using CinemaTicketBookingApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBookingApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }



        //create
        //[HttpPost]


        //Delete
        //[HttpDelete]

    }
}
