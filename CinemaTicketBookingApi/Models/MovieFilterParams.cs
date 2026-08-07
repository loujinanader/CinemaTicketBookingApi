namespace CinemaTicketBookingApi.Models
{
    public class MovieFilterParams:PaginationParams
    {
        public string? Search { get; set; }
        public string? Genre { get; set; }
        public string? SortBy { get; set; }
        public bool Descending { get; set; } = false;

    }
}
