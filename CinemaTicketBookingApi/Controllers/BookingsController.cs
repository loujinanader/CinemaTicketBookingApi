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
        //[HttpGet] //All Booking
        //        public IActionResult GetAllBookings(int pageId)
        //        {
        //                 var booking = _bookingService.using System.Collections.Generic;

        //                  interface IBookingService
        //                {
        //             void CancelBooking(int id);
        //            BookingDtos CreateBooking(CreateBookingDTO booking);
        //             IEnumerable<BookingDtos> GetAll(int pageId);
        //            }(pageId);
        //                        return Ok(booking);
        //        }
        //        //booking details
        [HttpGet("{id}")]
        public IActionResult GetBookingdetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}