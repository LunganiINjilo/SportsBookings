using SportsBookings.Models;
using SportsBookings.DbModels;
using System.Xml.Linq;

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
                ClubInfo = GetClubInfo(managerId),
                Amenities= GetAmenities(managerId),
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

        private List<Amenities> GetAmenities(int managerId)
        {
            var result = _context.tb_Facilities
            .Join(_context.tb_FacilitiesMap,facility => facility.Id, 
            map => map.FacilityId,
                (facility, map) => new { Facility = facility, Map = map })
            .Join(_context.tb_ClubManagerMap,
                 combined => combined.Map.ClubID,
                clubMap => clubMap.ClubID,
                (combined, clubMap) => new { combined.Facility, ClubMap = clubMap })
            .Where(x => x.ClubMap.ManagerId == managerId)
            .Select(x => new Amenities { ClubID = x.ClubMap.ClubID, Name = x.Facility.Name })
            .ToList();

            return result;
        }
    }
}
