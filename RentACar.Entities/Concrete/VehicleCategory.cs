using RentACar.Core.Entities;
using System.Collections.Generic;

namespace RentACar.Entities.Concrete
{
    public class VehicleCategory : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<VehicleBrand> VehicleBrands { get; set; }
    }
}
