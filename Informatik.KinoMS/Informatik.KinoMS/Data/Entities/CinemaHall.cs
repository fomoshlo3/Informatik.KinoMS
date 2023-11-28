using Informatik.KinoMS.Data.DbContexts;
using Informatik.KinoMS.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Informatik.KinoMS.Data.Entities
{
    public class CinemaHall
    {
        [Key]
        public int Id { get; set; }

        public int SeatsCount { get; set; }

        public int ScreeningId { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; } = new List<Screening>();

    }
}

