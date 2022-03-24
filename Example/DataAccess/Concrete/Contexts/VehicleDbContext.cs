using Example.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.DataAccess.Concrete.Contexts
{
    public class VehicleDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=VehicleDb;User Id=sa;Password=11223346;");
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Boat> Boats { get; set; }
    }
}
