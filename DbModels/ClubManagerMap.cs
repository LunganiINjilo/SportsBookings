using SportsBookings.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBookings.DbModels
{
    public class ClubManagerMap
    {
        [Key]
        public int Id { get; set; } 

        [ForeignKey("ClubManagerInformation")]
        public int ManagerId { get; set; }

        [ForeignKey("ClubInformation")]
        public int  ClubID { get; set; }

        public ClubInformation? ClubInformation { get; set; }

        public ClubManagerInformation? ClubManagerInformation { get; set; }
    }
}
