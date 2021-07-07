using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar.Entities.Concrete
{
    public class VehicleBrand : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int VehicleCategoryID { get; set; }
        public virtual VehicleCategory VehicleCategory { get; set; }
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
