using CinemaTicketBookingApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CinemaTicketBookingApi.DTOs;
using CinemaTicketBookingApi.Repository.BookingRepo;
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
        [HttpPost]
        public IActionResult CreateBooking( CreateBookingDTO booking)
        {
            //if (bookingDto == null)
            //{
            //    return BadRequest("Booking data is null.");
            //}
            var createdBooking = _bookingService.CreateBooking(booking);
            return Ok(createdBooking);
        }

        //Delete
        //[HttpDelete]


        //[HttpGet] //All Booking
        
        //booking details
    }
}
