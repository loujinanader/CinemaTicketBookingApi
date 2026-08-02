namespace CinemaTicketBookingApi.Exceptions.Movies
{
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException(string message)
          : base(message)
        {
        }

        public MovieNotFoundException(int movieId)
            : base($"the movie with the Id {movieId} was not found, please check the id and try again later")
        { }
    }
}
