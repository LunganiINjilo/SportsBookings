using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsBookings.DbModels;
using SportsBookings.Models;

namespace SportsBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ManagersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClubManagerInformation>>> Gettb_ClubManager()
        {
          if (_context.tb_ClubManager == null)
          {
              return NotFound();
          }
            return await _context.tb_ClubManager.ToListAsync();
        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClubManagerInformation>> GetClubManagerInformation(int id)
        {
          if (_context.tb_ClubManager == null)
          {
              return NotFound();
          }
            var clubManagerInformation = await _context.tb_ClubManager.FindAsync(id);

            if (clubManagerInformation == null)
            {
                return NotFound();
            }

            return clubManagerInformation;
        }

        // PUT: api/Managers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClubManagerInformation(int id, ClubManagerInformation clubManagerInformation)
        {
            if (id != clubManagerInformation.ManagerId)
            {
                return BadRequest();
            }

            _context.Entry(clubManagerInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubManagerInformationExists(id))
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

        // POST: api/Managers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClubManagerInformation>> PostClubManagerInformation(ClubManagerInformation clubManagerInformation)
        {
          if (_context.tb_ClubManager == null)
          {
              return Problem("Entity set 'AppDbContext.tb_ClubManager'  is null.");
          }
            _context.tb_ClubManager.Add(clubManagerInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClubManagerInformation", new { id = clubManagerInformation.ManagerId }, clubManagerInformation);
        }

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClubManagerInformation(int id)
        {
            if (_context.tb_ClubManager == null)
            {
                return NotFound();
            }
            var clubManagerInformation = await _context.tb_ClubManager.FindAsync(id);
            if (clubManagerInformation == null)
            {
                return NotFound();
            }

            _context.tb_ClubManager.Remove(clubManagerInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClubManagerInformationExists(int id)
        {
            return (_context.tb_ClubManager?.Any(e => e.ManagerId == id)).GetValueOrDefault();
        }
    }
}
