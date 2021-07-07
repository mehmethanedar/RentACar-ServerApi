using RentACar.Core.Entities;
using RentACar.Core.Entities.Concrete;
using RentACar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar.Entities.Concrete
{
    public class Employee : UserInformation, IEntity
    {
        public int Salary { get; set; }
        public int DealerID { get; set; }
        public virtual Dealer Dealer { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public string Username { get; set; }
        public string CitizenId { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ModificationDate { get; set; } = DateTime.Now;
        public string Phone_1 { get; set; }
        public string Phone_2 { get; set; }
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }

    }
}
