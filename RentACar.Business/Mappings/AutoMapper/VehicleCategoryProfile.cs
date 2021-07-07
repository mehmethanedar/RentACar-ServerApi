using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class VehicleCategoryProfile : Profile
    {
        public VehicleCategoryProfile()
        {
            CreateMap<VehicleCategoryAddDto, VehicleCategory>();
            CreateMap<VehicleCategory, VehicleCategoryGetDto>();
            CreateMap<VehicleCategoryUpdateDto, VehicleCategory>();
        }
    }
}
