using System.ComponentModel.DataAnnotations;

namespace SportsBookings.Models
{
    public class CountryInformation
    {
        [Key]
        public int CountryID { get; set; }

        [Required]
        public string? CountryName { get; set; }

        [Required]
        public string? CountryCode { get; set; }
    }
}
