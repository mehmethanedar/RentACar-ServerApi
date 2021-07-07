using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Add
{
    public class OrderAddDto : IDto
    {
        public double TotalAmount { get; set; }
        public int CustomerID { get; set; }
        public int DealerID { get; set; }
        public int VehicleID { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
