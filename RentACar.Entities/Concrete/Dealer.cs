using RentACar.Core.Entities;
using System;
using System.Collections.Generic;

namespace RentACar.Entities.Concrete
{
    public class Dealer : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime OpeningDate { get; set; }
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
