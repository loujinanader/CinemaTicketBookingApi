using CinemaTicketBookingApi.Exceptions.booking;
using CinemaTicketBookingApi.Exceptions.Movies;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CinemaTicketBookingApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // determine status code based on exception type
            var status = ex switch
            {
                MovieNotFoundException => StatusCodes.Status404NotFound,
                BookingNotFoundException => StatusCodes.Status404NotFound,
                MovieAlreadyExistsException => StatusCodes.Status409Conflict,
                MovieNotAvailableException => StatusCodes.Status400BadRequest,
                InsufficientSeatsException => StatusCodes.Status400BadRequest,
                ArgumentNullException => StatusCodes.Status400BadRequest,
                ArgumentException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError,
            };
            if (ex is KeyNotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(ex.Message);
            }

            context.Response.Clear();
            context.Response.StatusCode = status;
            context.Response.ContentType = "application/problem+json";

            var problem = new ProblemDetails
            {
                Status = status,
                Title = status == StatusCodes.Status500InternalServerError
                    ? "Internal Server Error"
                    : "Request Failed",
                Detail = ex.Message,
                Type = $"https://httpstatuses.com/{status}",
                Instance = context.Request.Path.ToString()
            };

            var json = JsonSerializer.Serialize(problem);
            await context.Response.WriteAsync(json);
        }

    }
}
