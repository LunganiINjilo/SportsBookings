using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsBookings.Models;

namespace SportsBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SessionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sessions
        [HttpGet]
        [Route("CountryInformation")]
        public async Task<ActionResult<IEnumerable<CountryInformation>>> GetCountryInformation()
        {
          if (_context.tb_Country == null)
          {
              return NotFound();
          }
            return await _context.tb_Country.ToListAsync();
        }


        // GET: api/Sessions
        [HttpGet]
        [Route("CountryStateInformation")]
        public async Task<ActionResult<IEnumerable<CountryStateInformation>>> GetCountryStateInformation()
        {
            if (_context.tb_CountryState == null)
            {
                return NotFound();
            }
            return await _context.tb_CountryState.ToListAsync();
        }


        [HttpGet]
        [Route("AvailableClubNames")]
        public async Task<ActionResult<IEnumerable<ClubInformation>>> GetAvailableClubNames()
        {
            if (_context.tb_Club == null)
            {
                return NotFound();
            }
            return await _context.tb_Club.ToListAsync();
        }


        [HttpGet]
        [Route("AvailableFacilities")]
        public async Task<ActionResult<IEnumerable<Facilities>>> GetAvailableFacilities()
        {
            if (_context.tb_Facilities == null)
            {
                return NotFound();
            }
            return await _context.tb_Facilities.ToListAsync();
        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryInformation>> GetCountryInformation(int id)
        {
          if (_context.tb_Country == null)
          {
              return NotFound();
          }
            var countryInformation = await _context.tb_Country.FindAsync(id);

            if (countryInformation == null)
            {
                return NotFound();
            }

            return countryInformation;
        }

        // PUT: api/Sessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryInformation(int id, CountryInformation countryInformation)
        {
            if (id != countryInformation.CountryID)
            {
                return BadRequest();
            }

            _context.Entry(countryInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryInformationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sessions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryInformation>> PostCountryInformation(CountryInformation countryInformation)
        {
          if (_context.tb_Country == null)
          {
              return Problem("Entity set 'AppDbContext.tb_Country'  is null.");
          }
            _context.tb_Country.Add(countryInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryInformation", new { id = countryInformation.CountryID }, countryInformation);
        }

        // DELETE: api/Sessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryInformation(int id)
        {
            if (_context.tb_Country == null)
            {
                return NotFound();
            }
            var countryInformation = await _context.tb_Country.FindAsync(id);
            if (countryInformation == null)
            {
                return NotFound();
            }

            _context.tb_Country.Remove(countryInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryInformationExists(int id)
        {
            return (_context.tb_Country?.Any(e => e.CountryID == id)).GetValueOrDefault();
        }
    }
}
