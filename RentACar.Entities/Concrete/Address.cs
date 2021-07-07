using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar.Entities.Concrete
{
    public class Address : IEntity
    {
        public int ID { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public int DistrictID { get; set; }
        public virtual District District { get; set; }
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int TownId { get; set; }
        public virtual Town Town { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Dealer> Dealers { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
