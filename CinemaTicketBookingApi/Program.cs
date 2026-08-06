using Asp.Versioning;
using CinemaTicketBookingApi.Data.DataBase;
using CinemaTicketBookingApi.Data.Mappers;
using CinemaTicketBookingApi.Repository.BookingRepo;
using CinemaTicketBookingApi.Repository.MovieRepo;
using CinemaTicketBookingApi.Services.Bookings;
using CinemaTicketBookingApi.Services.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using CinemaTicketBookingApi.Middleware;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CinemaTicketBookingApi", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "CinemaTicketBookingApi", Version = "v2" });
});

builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
}).AddApiExplorer(Options =>
{
    Options.GroupNameFormat = "'v'VVV";
    Options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IMapper, Mapper>();
//builder.Services.AddOpenApi();
builder.Services.AddDbContext<Movies_db>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema API V1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "Cinema API V2");
    });
}
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();