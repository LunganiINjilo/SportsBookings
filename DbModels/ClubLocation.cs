using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBookings.Models
{
    public class ClubLocation
    {
        [Key, Column(Order = 0)]
        public int LocationID { get; set; }

        [ForeignKey("CountryStateInformation"), Column(Order = 1)]
        public int StateID { get; set; }

        [ForeignKey("CountryInformation"), Column(Order = 2)]
        public int CountryID { get; set; }

        public string? StreetAdress { get; set; }   

        public string? PostaCode { get; set; }

        public CountryStateInformation? CountryStateInformation { get; set; }

        public CountryInformation? CountryInformation { get; set; }
    }
}
