using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
    public class HairSalonContext : DbContext
    {
        public DbSet<Stylist> stylist { get; set; }
        public DbSet<Client> client { get; set; }
        public DbSet<Appointment > appointment { get; set; }

        public HairSalonContext(DbContextOptions options) : base(options) { }
    }
}