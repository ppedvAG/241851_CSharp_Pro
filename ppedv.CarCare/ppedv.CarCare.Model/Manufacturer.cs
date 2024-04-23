namespace ppedv.CarCare.Model
{
    public class Manufacturer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
