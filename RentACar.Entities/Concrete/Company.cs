using RentACar.Core.Entities;
using RentACar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar.Entities.Concrete
{
    public class Company : User, IEntity
    {
        public string Brand { get; set; }
        public DateTime FoundationDate { get; set; }
        public string TaxNumber { get; set; }
        public string LogoUrl { get; set; }
        public string About { get; set; }
        public bool Status { get; set; } = true;
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Dealer> Dealers { get; set; }
    }
}
