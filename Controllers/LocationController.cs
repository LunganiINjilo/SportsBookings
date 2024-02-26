using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SportsBookings.Models; // Assuming your DbContext is defined here
using SportsBookings.DbModels;
using System.Diagnostics.Metrics;

namespace SportsBookings.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("countries")]
        public IActionResult GetCountries()
        {
            var countries = _context.tb_Country.Select(c => new CountryInformation
            {
                CountryID = c.CountryID,
                CountryName = c.CountryName,
                CountryCode = c.CountryCode
            }).ToList();

            return Ok(countries);
        }

        [HttpGet("countries/{countryId}/cities")]
        public IActionResult GetCities(int countryId)
        {
            var cities = _context.tb_CountryState
                                .Where(cs => cs.CountryID == countryId)
                                .Select(cs => new CountryStateInformation
                                {
                                    StateID = cs.StateID,
                                    StateName = cs.StateName,
                                    StateCode = cs.StateCode
                                })
                                .ToList();

            return Ok(cities);
        }
    }
}
