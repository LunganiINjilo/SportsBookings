using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBookings.DbModels
{
    public class FacilitiesMap
    {
        [Key, Column(Order = 0)]
        public int FacilityId { get; set; }

        [ForeignKey("ClubInformation"), Column(Order = 1)]
        public int ClubID { get; set; }

        public ClubInformation? ClubInformation { get; set; }

    }
}
