using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar.Entities.Concrete
{
    public class VehicleModel : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int VehicleBrandID { get; set; }
        public virtual VehicleBrand VehicleBrand { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
