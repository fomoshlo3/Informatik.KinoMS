using Informatik.KinoMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Informatik.KinoMS.Data.DbContexts
{
    public class CinemaDbContext : DbContext
    {
        public virtual DbSet<CinemaHall> Halls { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Screening> Screenings { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CinemaHall>()
                .HasData(
                new CinemaHall() { Id = 1, SeatsCount = 340 },
                new CinemaHall() { Id = 2, SeatsCount = 280 },
                new CinemaHall() { Id = 3, SeatsCount = 280 },
                new CinemaHall() { Id = 4, SeatsCount = 180 },
                new CinemaHall() { Id = 5, SeatsCount = 340 },
                new CinemaHall() { Id = 6, SeatsCount = 180 }
                );

            modelBuilder.Entity<Movie>()
                .HasData(
                new Movie()
                {
                    Id = 1,
                    Title = "Einer flog über das Kuckucksnest",
                    Description = "Richtig Lahmer Method-Acting Film",
                    PCA = 12,
                    PublishedDate = "1975",
                    Length = TimeSpan.Parse("1:30:00.000")
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Schindlers Liste",
                    Description = "Bewegendes Drama über den Holocaust",
                    PCA = 16,
                    PublishedDate = "1993",
                    Length = TimeSpan.Parse("3:15:00.000")
                },
                new Movie()
                {
                    Id = 3,
                    Title = "Inception",
                    Description = "Verwirrend genialer Science-Fiction-Thriller",
                    PCA = 16,
                    PublishedDate = "2010",
                    Length = TimeSpan.Parse("2:28:00.000")
                },
                new Movie()
                {
                    Id = 4,
                    Title = "Schindlers Liste",
                    Description = "Bewegendes Drama über den Holocaust",
                    PCA = 16,
                    PublishedDate = "1993",
                    Length = TimeSpan.Parse("3:15:00.000")
                },
                new Movie()
                {
                    Id = 5,
                    Title = "Der Pate",
                    Description = "Ein Klassiker des Mafiafilms",
                    PCA = 18,
                    PublishedDate = "1972",
                    Length = TimeSpan.Parse("2:55:00.000")
                },
                new Movie()
                {
                    Id = 6,
                    Title = "Forrest Gump",
                    Description = "Epische Reise eines einfachen Mannes",
                    PCA = 12,
                    PublishedDate = "1994",
                    Length = TimeSpan.Parse("2:22:00.000")
                },
                new Movie()
                {
                    Id = 7,
                    Title = "Der Herr der Ringe: Die Gefährten",
                    Description = "Epos über die Reise eines Hobbits",
                    PCA = 12,
                    PublishedDate = "2001",
                    Length = TimeSpan.Parse("2:58:00.000")
                });

            modelBuilder.Entity<Screening>()
                .HasData(
                new Screening()
                {
                    Id = 1,
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    HallId = 1,
                    StartTime = TimeOnly.Parse("15:00:00.000"),
                    MovieId = 1,
                },
                new Screening()
                {
                    Id = 2,
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    HallId = 2,
                    StartTime = TimeOnly.Parse("15:00:00.000"),
                    MovieId = 2,
                },
                new Screening()
                {
                    Id = 3,
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    HallId = 3,
                    StartTime = TimeOnly.Parse("15:00:00.000"),
                    MovieId = 3,
                },
                new Screening()
                {
                    Id = 4,
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    HallId = 4,
                    StartTime = TimeOnly.Parse("15:00:00.000"),
                    MovieId = 4,
                },
                new Screening()
                {
                    Id = 5,
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    HallId = 5,
                    StartTime = TimeOnly.Parse("15:00:00.000"),
                    MovieId = 5,
                },
                new Screening()
                {
                    Id = 6,
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    HallId = 1,
                    StartTime = TimeOnly.Parse("19:00:00.000"),
                    MovieId = 6
                },
                new Screening()
                {
                    Id = 7,
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    HallId = 2,
                    StartTime = TimeOnly.Parse("19:00:00.000"),
                    MovieId = 7,
                },
                new Screening()
                {
                    Id = 8,
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    HallId = 3,
                    StartTime = TimeOnly.Parse("19:00:00.000"),
                    MovieId = 7,
                },
                new Screening()
                {
                    Id = 9,
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    HallId = 4,
                    StartTime = TimeOnly.Parse("19:00:00.000"),
                    MovieId = 7,
                },
                new Screening()
                {
                    Id = 10,
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    HallId = 5,
                    StartTime = TimeOnly.Parse("19:00:00.000"),
                    MovieId = 7,
                });
        }
    }
}