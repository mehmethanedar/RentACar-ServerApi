using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class Invoice : IEntity
    {
        public int ID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int TotalPrice { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
    }
}
