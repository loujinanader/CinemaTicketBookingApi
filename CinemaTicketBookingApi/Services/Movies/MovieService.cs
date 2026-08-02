using CinemaTicketBookingApi.Data.Mappers;
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
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
            
       

        public MovieResponseDTO CreateMovie(CreateMovieDTO dTO)
        {
            ValidateBeforeCreate(dTO);
            Movie movieToCreate = _mapper.MapToMovie(dTO);
            Movie createdMoive = _repository.CreateMovie(movieToCreate);
            MovieResponseDTO responseDTO = _mapper.MapToMovieResponseDTO(createdMoive);
            return responseDTO;

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
