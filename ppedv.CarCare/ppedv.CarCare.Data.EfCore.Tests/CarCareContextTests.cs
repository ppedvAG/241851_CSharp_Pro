using ppedv.CarCare.Model;

namespace ppedv.CarCare.Data.EfCore.Tests
{
    public class CarCareContextTests
    {
        string conString = "Server=(localdb)\\mssqllocaldb;Database=CarCare_Test;Trusted_Connection=true;";

        [Fact]
        public void Can_create_DB()
        {
            var con = new CarCareContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_add_Car()
        {
            var man = new Manufacturer() { Name = "MX" };
            var car = new Car
            {
                Manufacturer = man,
                Color = "gelb",
                KW = 19,
                BuiltDate = DateTime.Now,
                Model = "C1"
            };
            var con = new CarCareContext(conString);
            con.Database.EnsureCreated();

            con.Add(car);
            var rows = con.SaveChanges();

            Assert.Equal(2, rows);
        }

        [Fact]
        public void Can_read_Car()
        {
            var man = new Manufacturer() { Name = "MX" };
            var car = new Car
            {
                Manufacturer = man,
                Color = "grün",
                KW = 12,
                BuiltDate = DateTime.Now,
                Model = "C2"
            };

            using (var con = new CarCareContext(conString))
            {
                con.Database.EnsureCreated();

                con.Add(car);
                var rows = con.SaveChanges();
            }

            using (var con = new CarCareContext(conString))
            {
                var loaded = con.Cars.Find(car.Id);
                Assert.NotNull(loaded);
                Assert.Equal(12, loaded.KW);
                Assert.Equal("grün", loaded.Color);
                Assert.Equal("C2", loaded.Model);
            }
        }
    }
}