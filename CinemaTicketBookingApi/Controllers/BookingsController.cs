using CinemaTicketBookingApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CinemaTicketBookingApi.DTOs;
using CinemaTicketBookingApi.Repository.BookingRepo;
namespace CinemaTicketBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        //create
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDTO booking)
        {
            var createdBooking = _bookingService.CreateBooking(booking);
            return Ok(createdBooking);
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            _bookingService.CancelBooking(id);
            return Ok();
        }

        [HttpGet] //All Booking
        public IActionResult GetAllBookings([FromQuery] int pageId)
        {
            var bookings = _bookingService.GetAllBookings(pageId);
            return Ok(bookings);
        }

        //booking details
        [HttpGet("{id}")]
        public IActionResult GetBookingdetails(int id)
        {
            var booking = _bookingService.GetBookingdetails(id);
            return Ok(booking);
        }
    }
}