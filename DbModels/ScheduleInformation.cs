using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBookings.DbModels
{
    public class ScheduleInformation
    {
        [Key]
        public int ScheduleID { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }


        [ForeignKey("CourtInformation")]
        public int CourtID { get; set; }

        public CourtInformation? CourtInformation { get; set; }
    }
}
