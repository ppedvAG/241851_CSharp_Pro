namespace ppedv.CarCare.Model
{
    public class Car : Entity
    {
        public string Model { get; set; } = string.Empty;
        public int KW { get; set; }
        public DateTime BuiltDate { get; set; }
        public string? Color { get; set; }
        
        public required Manufacturer Manufacturer { get; set; }
    }
}
