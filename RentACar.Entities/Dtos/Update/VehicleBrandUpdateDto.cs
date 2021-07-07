using RentACar.Core.Entities;

namespace RentACar.Entities.Dtos.Update
{
    public class VehicleBrandUpdateDto:IDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int VehicleCategoryID { get; set; }
    }
}
