using CinemaTicketBookingApi.Models;


namespace CinemaTicketBookingApi.Services.Filter
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();
        public PagedResult<TaskItem> GetAll(MovieFilterParams filter)
        {
            var query = _tasks.AsQueryable();
            if(!string.IsNullOrEmpty(filter.Search))
                query = query.Where(t => t.Title.Contains(filter.Search,StringComparison.OrdinalIgnoreCase));
            if (filter.IsCompleted.HasValue)
                query = query.Where(t => t.IsCompleted == filter.IsCompleted.Value);
            var totalCount = query.Count();
            var data = query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize).ToList();
            return new PagedResult<TaskItem>
            {
                Data = data,
                Page = filter.Page,
                PageSize = filter.PageSize,
                TotalCount = totalCount
            };
        }
    }
}
