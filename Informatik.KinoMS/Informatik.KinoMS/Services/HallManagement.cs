using Informatik.KinoMS.Data.DbContexts;
using Informatik.KinoMS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Informatik.KinoMS.Services
{
    public class HallManagement : IHallManagement
    {
        private readonly IDbContextFactory<CinemaDbContext> factory;

        public HallManagement(IDbContextFactory<CinemaDbContext> factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// queries all Entries in Halls table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CinemaHall>> GetAllAsync() 
        {
            try
            {
                using (var ctx =  factory.CreateDbContext()) 
                {
                    return await ctx.Halls.AsNoTracking().ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CinemaHall> GetByIdAsync(int id)
        {
            try
            {
                using (var ctx = factory.CreateDbContext())
                {
                    var hall = await ctx.Halls.FindAsync(id);

                    if (hall != null)
                    {
                        return hall;
                    }
                    
                    return default;
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }
    }

    public interface IHallManagement
    {
        Task <IEnumerable<CinemaHall>> GetAllAsync();
        Task <CinemaHall> GetByIdAsync(int HallId);
    }
}
