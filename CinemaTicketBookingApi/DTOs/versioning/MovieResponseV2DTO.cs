namespace CinemaTicketBookingApi.DTOs.versioning
{
    public class MovieResponseV2DTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; } // Duration in minutes
        public int RelaeseYear { get; set; }
        public int AvailableSeats { get; set; }
        public bool AvailableInCinema { get; set; }

    }
}
