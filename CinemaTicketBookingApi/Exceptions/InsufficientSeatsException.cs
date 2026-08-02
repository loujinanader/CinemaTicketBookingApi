namespace CinemaTicketBookingApi.Exceptions
{
    public class InsufficientSeatsException : Exception
    {
        public InsufficientSeatsException(string message)
          : base(message)
        {
        }
    }
}
