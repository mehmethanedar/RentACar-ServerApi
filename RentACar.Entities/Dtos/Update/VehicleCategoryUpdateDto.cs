using RentACar.Core.Entities;

namespace RentACar.Entities.Dtos.Update
{
    public class VehicleCategoryUpdateDto : IDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
