namespace Example.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public bool HeadLight { get; set; }
        public virtual Color Color { get; set; }
        public virtual Car Car { get; set; }
        public virtual Bus Bus { get; set; }
        public virtual Boat Boat { get; set; }
    }

    public class Car
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string Wheel { get; set; }
    }
    public class Bus
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
    }
    public class Boat
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
    }
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
