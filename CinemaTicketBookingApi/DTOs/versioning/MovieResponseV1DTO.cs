namespace CinemaTicketBookingApi.DTOs.versioning
{
    public class MovieResponseV1DTO
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int AvailableSeats { get; set; }
    }
}
