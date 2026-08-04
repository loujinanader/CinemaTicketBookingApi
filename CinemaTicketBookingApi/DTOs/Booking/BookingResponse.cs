namespace CinemaTicketBookingApi.DTOs.Booking
{
    public class BookingResponseDto
    {
        public string MovieName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberofTickets { get; set; }

    }
}
