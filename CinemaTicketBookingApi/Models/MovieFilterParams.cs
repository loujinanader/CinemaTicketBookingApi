namespace CinemaTicketBookingApi.Models
{
    public class MovieFilterParams:PaginationParams
    {
        public string? Search { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatedBefore { get; set; }    
    }
}
