using RentACar.Core.Entities;

namespace RentACar.Entities.Concrete
{
    public class OrderItem : IEntity
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public int VehicleID { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
