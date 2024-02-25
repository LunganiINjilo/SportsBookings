using Microsoft.AspNetCore.Mvc;
using SportsBookings.Models;

namespace SportsBookings.Managers
{
    public interface ISessionManager
    {
        Task<SessionData> GetSessionDataAsync(int managerId);
    }
}
