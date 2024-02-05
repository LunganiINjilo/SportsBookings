using System.ComponentModel.DataAnnotations;

namespace SportsBookings.Models
{
    public class CourtFeatureInformation
    {
        [Key]
        public int FeatureID { get; set; }

        [Required]
        public string? FeatureName { get; set; } 
    }
}
