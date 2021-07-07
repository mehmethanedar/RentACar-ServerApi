using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Update
{
    public class OrderUpdateDto : IDto
    {
        public int ID { get; set; }
        public double TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
        public int CustomerID { get; set; }
        public int DealerID { get; set; }
        public int VehicleID { get; set; }
    }
}
