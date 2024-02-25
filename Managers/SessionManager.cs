using SportsBookings.Models;
using SportsBookings.DbModels;

namespace SportsBookings.Managers
{
    public class SessionManager : ISessionManager
    {

        private readonly AppDbContext _context;

        public SessionManager(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SessionData> GetSessionDataAsync(int managerId)
        {
            var session = new SessionData
            {
                ManagerID = managerId,
                ClubInfo = GetClubInfo(managerId)
            };
            return await Task.FromResult(session);
        }

        private List<ClubInfoData> GetClubInfo(int managerId)
        {
            var query = from cmMap in _context.tb_ClubManagerMap
                        join club in _context.tb_Club on cmMap.ClubID equals club.ClubID
                        join manager in _context.tb_ClubManager on cmMap.ManagerId equals manager.ManagerId
                        join court in _context.tb_Court on cmMap.ClubID equals court.ClubID
                        join sport in _context.tb_Sport on court.SportID equals sport.SportID
                        where cmMap.ManagerId == managerId
                        select new ClubInfoData
                        {
                            ClubName = club.ClubName,
                            CourtID = court.CourtID,
                            SportName = sport.SportName
                        };

            var result = query.ToList();

            return result;
        }
    }
}
