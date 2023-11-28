using System.ComponentModel.DataAnnotations;

namespace Informatik.KinoMS.Data.Entities
{
    public class Screening
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }
        public DateOnly Date { get; set; }

        public int MovieId { get; set; }
        public int HallId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual CinemaHall Hall { get; set; }
    }
}