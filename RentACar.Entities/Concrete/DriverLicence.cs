using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentACar.Entities.Concrete
{
    public class DriverLicence : IEntity
    {
        public int ID { get; set; }
        public string LicenceClass { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
