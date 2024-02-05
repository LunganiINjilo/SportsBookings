using System.ComponentModel.DataAnnotations;

namespace SportsBookings.Models
{
    public class CourtFeatureType
    {
        [Key]
        public int FeatureTypeID { get; set; }

        [Required]
        public string? FeatureType { get; set; }
    }
}
