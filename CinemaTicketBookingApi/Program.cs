using CinemaTicketBookingApi.Data;
using CinemaTicketBookingApi.Repository.BookingRepo;
using CinemaTicketBookingApi.Repository.MovieRepo;
using CinemaTicketBookingApi.Services.Movies;
//using CinemaTicketBookingApi.Services.Bookings;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();


builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
//builder.Services.AddScoped<IBookingService, BookingService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddDbContext<Movies_db>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
    
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
