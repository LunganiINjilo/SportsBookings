using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsBookings.Managers;
using SportsBookings.Models;

namespace SportsBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionManager _sessionManager;

        public SessionsController(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        [HttpGet]
        [Route("SessionData")]
        public async Task<ActionResult<SessionData>> GetSessionDataAync()
        {
            return Ok(await _sessionManager.GetSessionDataAsync(1).ConfigureAwait(false));
        }
    }
}
