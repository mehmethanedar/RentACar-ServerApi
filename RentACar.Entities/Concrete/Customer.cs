using RentACar.Core.Entities;
using RentACar.Core.Entities.Concrete;
using RentACar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int ID { get; set; }
        public string CitizenId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ModificationDate { get; set; } = DateTime.Now;
        public string Phone_1 { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; } = true;
        public int DriverLicenceID { get; set; }
        public virtual DriverLicence DriverLicence { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
