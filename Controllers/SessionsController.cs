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

        [HttpPost]
        [Route("ClubManagerInformation")]
        public ActionResult<ClubManagerInformation> GetClubManagerInformation([FromUri] string email)
        {
            if (_context.tb_ClubManager == null)
            {
                return NotFound();
            }

            return Ok(_context.tb_ClubManager.Where(x => x.Email == email));
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

        [HttpGet]
        [Route("OpeningHours")]
        public async Task<ActionResult<IEnumerable<OpeningHours>>> GetOpeningHours()
        {
            if (_context.tb_OpeningHours == null)
            {
                return NotFound();
            }

            return await _context.tb_OpeningHours.ToListAsync();
        }

        [HttpPost]
        [Route("PostOpeningHours")]
        public async Task<ActionResult<OpeningHours>> PostOpeningHours(OpeningHours openingHours)
        {
            if (_context.tb_OpeningHours == null)
            {
                return Problem("Entity set 'AppDbContext.tb_OpeningHours'  is null.");
            }
            _context.tb_OpeningHours.Add(openingHours);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOpeningHours", new { id = openingHours.Id }, openingHours);
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

    }
}
