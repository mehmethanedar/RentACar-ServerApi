using RentACar.Core.Entities;
using RentACar.Entities.Concrete;

namespace RentACar.Entities.Dtos.Get
{
    public class VehicleModelGetDto : IDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual VehicleBrandGetDto VehicleBrand { get; set; }
    }
}
