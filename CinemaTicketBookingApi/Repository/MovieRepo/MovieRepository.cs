using CinemaTicketBookingApi.Data.DataBase;
using CinemaTicketBookingApi.Models;
namespace CinemaTicketBookingApi.Repository.MovieRepo
{
    public class MovieRepository : IMovieRepository
    {
        private readonly Movies_db _db;
        public MovieRepository(Movies_db db)
        {
            _db = db;
        }
        public PagedResult<Movie> GetAllMovies(MovieFilterParams filter)
        {
            IQueryable<Movie> query = _db.Movies;
            // Search
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(m =>
                    m.Title.Contains(filter.Search));
            }
            // Filter
            if (!string.IsNullOrWhiteSpace(filter.Genre))
            {
                query = query.Where(m =>
                    m.Genre == filter.Genre);
            }
            // Sorting
            if (!string.IsNullOrWhiteSpace(filter.SortBy))
            {
                switch (filter.SortBy.ToLower())
                {
                    case "title":

                        query = filter.Descending
                            ? query.OrderByDescending(m => m.Title)
                            : query.OrderBy(m => m.Title);

                        break;

                    case "releaseyear":

                        query = filter.Descending
                            ? query.OrderByDescending(m => m.ReleaseYear)
                            : query.OrderBy(m => m.ReleaseYear);

                        break;
                }
            }
            int totalCount = query.Count();

            var data = query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();
            return new PagedResult<Movie>
            {
                Data = data,
                Page = filter.Page,
                PageSize = filter.PageSize,
                TotalCount = totalCount
            };
        }
        public Movie GetMovieById(int id) 
            => _db.Movies.FirstOrDefault(m => m.Id == id);
        public Movie CreateMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return movie;
        } 
        public Movie UpdateMovie(Movie movie)
        {
            _db.SaveChanges();
            return movie;
        }

        public void DeleteMovie(Movie movie) {
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }
        public bool MovieTitleExists(string title)
            => _db.Movies.Any(m => m.Title == title);
        public Movie GetMovieByTitle(string title)
             => _db.Movies.FirstOrDefault(m => m.Title == title);
    }
}
