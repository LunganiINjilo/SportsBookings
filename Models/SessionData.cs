namespace SportsBookings.Models
{
    public class SessionData
    {
        public int ManagerID { get; set; }
        public List<ClubInfoData>? ClubInfo { get; set; }
    }
}
