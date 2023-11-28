using System.ComponentModel.DataAnnotations;

namespace Informatik.KinoMS.Data.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PCA { get; set; }
        public string PublishedDate { get; set; } = string.Empty;
        public TimeSpan Length { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; } = new List<Screening>();
    }
}
