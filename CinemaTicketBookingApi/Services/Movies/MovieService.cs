using CinemaTicketBookingApi.DTOs.Movie;
using CinemaTicketBookingApi.Exceptions;
using CinemaTicketBookingApi.Exceptions.Movies;
using CinemaTicketBookingApi.Models;
using CinemaTicketBookingApi.Repository.MovieRepo;


namespace CinemaTicketBookingApi.Services.Movies
{
    public partial class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public MovieResponseDTO CreateMovie(CreateMovieDTO dTO)
        {
            if (dTO == null) 
                throw new ArgumentNullException(nameof(dTO));


            Movie movieToCreate = new Movie
            {
                Title = dTO.Title,
                ReleaseYear = dTO.ReleaseYear,
                AvailableInCinema = true,
                AvailableSeats = dTO.AvailableSeats,
                Duration = dTO.Duration,
                Genre = dTO.Genre
            };


            Movie createdMoive =  _repository.CreateMovie(movieToCreate);
            //return createdMoive;

            MovieResponseDTO movieResponse = new MovieResponseDTO {
                ID = createdMoive.Id,
                Title = createdMoive.Title,
                ReleaseYear = createdMoive.ReleaseYear,
                AvailableSeats = createdMoive.AvailableSeats,
                Duration = createdMoive.Duration,
                Genre = createdMoive.Genre

            };
            return movieResponse;


        }
        public void DeleteMovie(int movieId)
        {
            Movie movieToBeDeleted = _repository.GetMovieById(movieId);
            ValidateMovieBeforeDelete(movieToBeDeleted, movieId);

            _repository.DeleteMovie(movieToBeDeleted);
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
