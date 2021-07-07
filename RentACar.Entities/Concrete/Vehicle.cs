using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class Vehicle : IEntity
    {
        public int ID { get; set; }
        public int FuelTypeID { get; set; }
        public virtual FuelType FuelType { get; set; }
        public int GearTypeID { get; set; }
        public virtual GearType GearType { get; set; }
        public int VehicleModelID { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public int ColorID { get; set; }
        public virtual Color Color { get; set; }
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public int CaseTypeID { get; set; }
        public virtual CaseType CaseType { get; set; }
        public string DamageStatus { get; set; }
        public string Explanation { get; set; }
        public int Kilometer { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsExists { get; set; }
        public int DailyCost { get; set; }
        public int ViewsCount { get; set; }
        public string Pictures { get; set; }
        public int seats { get; set; }
        public string speed { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
