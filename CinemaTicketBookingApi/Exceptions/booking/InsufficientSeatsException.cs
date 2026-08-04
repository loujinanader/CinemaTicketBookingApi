namespace CinemaTicketBookingApi.Exceptions.booking
{
    public class InsufficientSeatsException : Exception
    {
        public InsufficientSeatsException(string message)
          : base(message)
        {
        }
    }
}
