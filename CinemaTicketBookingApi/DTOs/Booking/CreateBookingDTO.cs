using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBookingApi.DTOs.Booking
{
    public class CreateBookingDTO
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Range(1, int.MaxValue)]
        public int NumberOfTickets { get; set; }
        [Required]
        public string MovieName { get; set; }
    }
}
