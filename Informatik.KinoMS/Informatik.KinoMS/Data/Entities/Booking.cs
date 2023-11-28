using System.ComponentModel.DataAnnotations;

namespace Informatik.KinoMS.Data.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string CustomerName { get; set; }

        public int ScreeningId { get; set; }

        public virtual Screening Screening { get; set; }
    }
}
