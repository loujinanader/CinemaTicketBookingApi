using CinemaTicketBookingApi.Exceptions.booking;
using CinemaTicketBookingApi.Exceptions.Movies;
using System.Text.Json;
namespace CinemaTicketBookingApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private static async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            switch (ex)
            {
                case MovieNotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                case BookingNotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                case MovieAlreadyExistsException:
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    break;
                case MovieNotAvailableException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                case InsufficientSeatsException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                case ArgumentNullException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                case ArgumentException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }
            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}