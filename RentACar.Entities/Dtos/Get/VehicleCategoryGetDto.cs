using RentACar.Core.Entities;

namespace RentACar.Entities.Dtos.Get
{
    public class VehicleCategoryGetDto : IDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
