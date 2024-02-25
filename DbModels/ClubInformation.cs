using System.ComponentModel.DataAnnotations;

namespace SportsBookings.DbModels
{
    public class ClubInformation
    {
        [Key]
        public int ClubID { get; set; }

        [Required]
        public string? ClubName { get; set; }
    }
}
