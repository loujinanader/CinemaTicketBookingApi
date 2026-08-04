namespace CinemaTicketBookingApi.Exceptions.Movies
{
    public class MovieNotAvailableException : Exception
    {
        public MovieNotAvailableException(int movieId)
            : base($"Movie with ID {movieId} is currently not available in the cinema.")
        {
        }
    }
}
