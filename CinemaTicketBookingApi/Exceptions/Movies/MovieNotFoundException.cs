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
        //     if (_repository.MovieTitleExists(movie.Title))
        //        {
        //            throw new MovieAlreadyExistsException("A movie with this title already exists.");
        //}
        //        return true;
        public MovieNotFoundException(string title, string message)
                : base($"the movie with the title {title} was not found, please check the title and try again later")
        {
        }
    }
}