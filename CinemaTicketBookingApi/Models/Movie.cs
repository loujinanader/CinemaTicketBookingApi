namespace CinemaTicketBookingApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Genre { get; set; }
        public int Duration { get; set; } //minutes
        public int ReleaseYear { get; set; }
        public int AvailableSeats { get; set; }
        public bool AvailableInCinema { get; set; }


        // One Movie has many Bookings
        public ICollection<Booking> Bookings { get; set; }
    }
}
