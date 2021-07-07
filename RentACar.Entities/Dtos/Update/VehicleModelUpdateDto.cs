using RentACar.Core.Entities;

namespace RentACar.Entities.Dtos.Update
{
    public class VehicleModelUpdateDto : IDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int VehicleBrandID { get; set; }
    }
}
