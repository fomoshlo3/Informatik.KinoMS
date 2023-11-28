using Informatik.KinoMS.Data;
using Informatik.KinoMS.Data.DbContexts;
using Informatik.KinoMS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Informatik.KinoMS.Services
{
    public class MovieManagement : IMovieManagement
    {
        private readonly IDbContextFactory<CinemaDbContext> factory;

        public MovieManagement(IDbContextFactory<CinemaDbContext> factory)
        {
            this.factory = factory;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            try
            {
                using (var ctx = factory.CreateDbContext())
                {
                    var movies = await ctx.Movies.AsNoTracking().ToListAsync();

                    if(movies != null) return movies;

                    return default;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            try
            {
                using (var ctx = factory.CreateDbContext())
                {
                    var movie = await ctx.Movies.FindAsync(id);

                    if (movie != null) return movie;

                    return default;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MovieDetailsDto> GetByIdAsync2(int id)
        {
            using (var ctx = factory.CreateDbContext())
            {
                var movie = await ctx.Movies.FindAsync(id);

                return new MovieDetailsDto(
                    movie.Title,
                    movie.Description,
                    movie.PCA,
                    movie.PublishedDate,
                    movie.Length
                    );
            }
        } 
    }

    public interface IMovieManagement
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
    }
}
