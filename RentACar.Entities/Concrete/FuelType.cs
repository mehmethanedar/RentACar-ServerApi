using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentACar.Entities.Concrete
{
    public class FuelType : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
