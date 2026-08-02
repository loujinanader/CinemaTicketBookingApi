namespace CinemaTicketBookingApi.Exceptions.Movies
{
    public class MovieAlreadyExistsException : Exception
    { public MovieAlreadyExistsException(string message)
          : base(message)
        {
        }
    }
}
