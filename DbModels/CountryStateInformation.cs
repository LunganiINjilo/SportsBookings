using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBookings.Models
{
    public class CountryStateInformation
    {
        [Key, Column(Order = 0)]
        public int StateID { get; set; }

        [Required]
        public string? StateName { get; set; }

        [Required]
        public string? StateCode { get; set; }

        [ForeignKey("countryInformation"), Column(Order = 1)]
        public int CountryID { get; set; }

        public CountryInformation? countryInformation { get; set; }
    }
}
