namespace CinemaTicketBookingApi.DTOs.Movie
{
    public class CreateMovieDTO
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; } //minutes
        public int ReleaseYear { get; set; }
        public int AvailableSeats { get; set; }

    }
}
