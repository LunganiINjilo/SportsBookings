using System.ComponentModel.DataAnnotations;

namespace SportsBookings.Models
{
    public class OpeningHours
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Startdate { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
    }
}
