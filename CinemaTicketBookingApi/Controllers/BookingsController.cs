using Microsoft.AspNetCore.Mvc;
using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Services.Bookings;
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
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDTO booking)
        {
            var createdBooking = _bookingService.CreateBooking(booking);
            return Created("", createdBooking);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            _bookingService.CancelBooking(id);
            return Ok();
        }
        [HttpGet] //All Booking
        public IActionResult GetAllBookings(int pageNumber = 1, int pageSize = 10)
        {
            var bookings = _bookingService.GetAllBookings(pageNumber, pageSize);
            return Ok(bookings);
        }
        //booking details
        [HttpGet("{id}")]
        public IActionResult GetBookingdetails(int id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }
    }
}