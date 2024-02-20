using System.ComponentModel.DataAnnotations;

namespace SportsBookings.Models
{
    public class ClubManagerInformation
    {
        [Key]
        public int ManagerId { get; set; }

        [Required]
        public string? ManagerName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? PasswordHash { get; set; }
    }
}
