using CinemaTicketBookingApi.Data.Mappers;
using CinemaTicketBookingApi.DTOs.Movie;
using CinemaTicketBookingApi.DTOs.versioning;
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
        public MovieResponseDTO UpdateMovie(UpdateMovieDTO dTO)
        {//Book if the movie still available in the cinema. 
            ValidateMovieBeforeUpdate(dTO);
            var existingMovie = _repository.GetMovieById(dTO.Id);
            if (existingMovie == null)
                throw new MovieNotFoundException(dTO.Id);
            _mapper.MapToExistingMovie(dTO, existingMovie);
            Movie updatedMovie = _repository.UpdateMovie(existingMovie);
            return _mapper.MapToMovieResponseDTO(updatedMovie);
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
            if (movie == null)
            throw new MovieNotFoundException(id);
            return movie;
        }
        public bool MovieTitleExists(string title)//Duplicate movie titles are not allowed. 

        { var movie = _repository.GetMovieByTitle(title);

            if (_repository.MovieTitleExists(movie.Title))
               throw new MovieAlreadyExistsException("A movie with this title already exists.");
               return true;
        }
        public IEnumerable<MovieResponseDTO> GetAllMovies(int pageNumber, int pageSize)
        {
            var movies = _repository.GetAllMovies(pageNumber, pageSize);

            return movies.Select(m => _mapper.MapToMovieResponseDTO(m));
        }
        public IEnumerable<MovieResponseV1DTO> GetAllMoviesV1(int pageNumber, int pageSize)
        {
            var movies = _repository.GetAllMovies(pageNumber, pageSize);
            return movies.Select(m => _mapper.MapToMovieResponseV1(m));

        }

        public IEnumerable<MovieResponseV2DTO> GetAllMoviesV2(int pageNumber, int pageSize){
            var movies = _repository.GetAllMovies(pageNumber, pageSize);
            return movies.Select(m => _mapper.MapToMovieResponseV2(m));
        }
    }
}
