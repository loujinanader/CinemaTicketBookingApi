using Microsoft.EntityFrameworkCore;
using CinemaTicketBookingApi.Models;

namespace CinemaTicketBookingApi.Data
{
    public class Movies_db : DbContext
    {
        public Movies_db(DbContextOptions<Movies_db> options) : base(options)
        { }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Movie> Movies
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Movie
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.Title)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(m => m.Title)
                      .IsUnique();

                entity.Property(m => m.Genre)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(m => m.Duration)
                      .IsRequired();

                entity.Property(m => m.ReleaseYear)
                      .IsRequired();

                entity.Property(m => m.AvailableSeats)
                      .IsRequired();

                entity.Property(m => m.AvailableInCinema)
                      .IsRequired();
            });

            // Booking
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(b => b.CustomerName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(b => b.CustomerEmail)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(b => b.BookingDate)
                      .IsRequired();

                entity.Property(b => b.NumberOfTickets)
                      .IsRequired();

                entity.HasOne<Movie>()
                      .WithMany()
                      .HasForeignKey(b => b.MovieId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
