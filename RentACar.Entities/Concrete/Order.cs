using RentACar.Core.Entities;
using System;
using System.Collections.Generic;

namespace RentACar.Entities.Concrete
{
    public class Order : IEntity
    {
        public int ID { get; set; }
        public double TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public int DealerID { get; set; }
        public virtual Dealer Dealer { get; set; }
        public int VehicleID { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
