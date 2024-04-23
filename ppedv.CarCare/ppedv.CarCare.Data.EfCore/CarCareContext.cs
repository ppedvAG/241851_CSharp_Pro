using Microsoft.EntityFrameworkCore;
using ppedv.CarCare.Model;

namespace ppedv.CarCare.Data.EfCore
{
    public class CarCareContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        string conString;

        public CarCareContext(string conString)
        {
            this.conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString);
        }
    }
}
