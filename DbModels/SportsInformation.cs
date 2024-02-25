using System.ComponentModel.DataAnnotations;

namespace SportsBookings.Models
{
    public class SportsInformation
    {
        [Key]
        public int SportID { get; set; }

        [Required]
        public string? SportName { get; set; }
    }
}
