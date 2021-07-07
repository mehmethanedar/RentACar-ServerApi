using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Add
{
    public class InvoiceAddDto : IDto
    {
        public DateTime InvoiceDate { get; set; }
        public int TotalPrice { get; set; }
        public int EmployeeID { get; set; }
        public int OrderID { get; set; }
    }
}
