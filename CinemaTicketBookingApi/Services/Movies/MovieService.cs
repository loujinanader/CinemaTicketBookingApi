using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.Repository.MovieRepo;
using CinemaTicketBookingApi.Exceptions;


namespace CinemaTicketBookingApi.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public Movie CreateMovie(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));


            return _repository.CreateMovie(movie);
        }
        public void DeleteMovie(Movie movie)
        {       //Book if the movie still available in the cinema. 
            if (movie == null) throw new ArgumentNullException(nameof(movie));
            _repository.DeleteMovie(movie);

        }

      
        public Movie GetMovieById(int id)
        {
            var movie = _repository.GetMovieById(id);
            if (movie == null) throw new Exception($"Movie with ID {id} not found.");
            return movie;
        }

        //Duplicate movie titles are not allowed. 
        public bool MovieTitleExists(string title)
        { var movie = _repository.GetMovieByTitle(title);

            if (_repository.MovieTitleExists(movie.Title))
            {
                throw new MovieAlreadyExistsException("A movie with this title already exists.");
            }
            return true;
        }

        public Movie UpdateMovie(Movie movie)
        {//Book if the movie still available in the cinema. 

            if (movie == null) throw new ArgumentNullException(nameof(movie));
            var existingMovie = _repository.GetMovieById(movie.Id);
            if (existingMovie == null) throw new Exception($"Movie with ID {movie.Id} not found.");
            return _repository.UpdateMovie(movie);
        }
        public IEnumerable<Movie> GetAllMovies(int pageNumber, int pageSize)
        {
            return _repository.GetAllMovies(pageNumber, pageSize);
        }

       
    }
}
