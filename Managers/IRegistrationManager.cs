using Microsoft.AspNetCore.Mvc;

namespace SportsBookings.Managers
{
    public interface IRegistrationManager
    {
        Task<ActionResult> RegisterClubAsync();
    }
}
