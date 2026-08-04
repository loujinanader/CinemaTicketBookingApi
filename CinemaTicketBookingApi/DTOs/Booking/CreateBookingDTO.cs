namespace CinemaTicketBookingApi.DTOs.Booking
{
    public class CreateBookingDTO
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfTickets { get; set; }
        public int MovieId { get; set; }
    }
}
