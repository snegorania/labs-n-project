using Microsoft.EntityFrameworkCore;

namespace SensorApp.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Indication> Indications { get; set; }
    }
}
