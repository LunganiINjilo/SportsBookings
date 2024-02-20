using Microsoft.AspNetCore.Mvc;
using SportsBookings.Managers;

namespace SportsBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubRegistrationController : ControllerBase
    {
        private readonly IRegistrationManager _registrationManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registrationManager"></param>
        public ClubRegistrationController(IRegistrationManager registrationManager)
        {
            _registrationManager = registrationManager;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterClub()
        {
            return Ok(await _registrationManager.RegisterClubAsync().ConfigureAwait(false));
        }
    }
}
