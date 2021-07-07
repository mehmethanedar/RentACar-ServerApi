using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Get
{
    public class OrderItemGetDto : IDto
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public int OrderID { get; set; }
        public int VehicleID { get; set; }
    }
}
