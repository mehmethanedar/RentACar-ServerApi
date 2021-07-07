using RentACar.Core.Entities;

namespace RentACar.Entities.Dtos.Add
{
    public class VehicleModelAddDto : IDto
    {
        public string Name { get; set; }
        public int VehicleBrandID { get; set; }
    }
}
