namespace CinemaTicketBookingApi.DTOs
{
    public class CreateBookingDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
