using CinemaTicketBookingApi.DTOs.Booking;
using CinemaTicketBookingApi.Services.Bookings;
using Microsoft.AspNetCore.Mvc;
namespace CinemaTicketBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
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
            return CreatedAtAction(nameof(GetBookingdetails), new { id = createdBooking.Id }, createdBooking);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            _bookingService.CancelBooking(id);
            return NoContent();
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