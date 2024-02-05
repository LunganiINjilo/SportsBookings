using Microsoft.EntityFrameworkCore;

namespace SportsBookings.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CountryInformation> tb_Country { get; set; }  
        
        public DbSet<SportsInformation> tb_Sport { get; set; }

        public DbSet<ClubInformation> tb_Club { get; set; }

        public DbSet<CourtFeatureType> tb_CourtFeatureType { get; set; }

        public DbSet<Facilities> tb_Facilities { get; set; }

        public DbSet<CourtFeatureInformation> tb_CourtFeature { get; set; }

        public DbSet<CountryStateInformation> tb_CountryState { get; set; }

        public DbSet<ClubLocation> tb_ClubLocation { get; set; }
  
        public DbSet<FacilitiesMap> tb_FacilitiesMap { get; set; }

        public DbSet<CourtInformation> tb_Court { get; set; }

        public DbSet<ScheduleInformation> tb_Schedule { get; set; }
    }
}
