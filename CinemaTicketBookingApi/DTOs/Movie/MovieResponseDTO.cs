namespace CinemaTicketBookingApi.DTOs.Movie
{
    public class MovieResponseDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; } //minutes
        public int ReleaseYear { get; set; }
        public int AvailableSeats { get; set; }

    }
}
