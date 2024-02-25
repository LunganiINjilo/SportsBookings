using SportsBookings.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBookings.DbModels
{
    public class CourtInformation
    {
        [Key, Column(Order = 0)]
        public int CourtID { get; set; }

        [ForeignKey("CourtFeatureInformation"), Column(Order = 1)]
        public int FeatureID { get; set; }

        [ForeignKey("CourtFeatureType"), Column(Order = 2)]
        public int FeatureTypeID { get; set; }

        [ForeignKey("SportsInformation"), Column(Order = 3)]
        public int SportID { get; set; }

        [ForeignKey("ClubInformation"), Column(Order = 4)]
        public int ClubID { get; set; }

        public CourtFeatureInformation? CourtFeatureInformation { get; set; }
        
        public CourtFeatureType? CourtFeatureType { get; set; }

        public SportsInformation? SportsInformation { get; set; }

        public ClubInformation? ClubInformation { get; set; }
    }
}
