using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class VehicleModelProfile : Profile
    {
        public VehicleModelProfile()
        {
            CreateMap<VehicleModelAddDto, VehicleModel>();
            CreateMap<VehicleModel, VehicleModelGetDto>();
            CreateMap<VehicleModelUpdateDto, VehicleModel>();
        }
    }
}
