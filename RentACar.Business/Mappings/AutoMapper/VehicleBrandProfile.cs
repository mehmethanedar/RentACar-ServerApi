using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class VehicleBrandProfile : Profile
    {
        public VehicleBrandProfile()
        {
            CreateMap<VehicleBrandAddDto, VehicleBrand>();
            CreateMap<VehicleBrand, VehicleBrandGetDto>();
            CreateMap<VehicleBrandUpdateDto, VehicleBrand>();
        }
    }
}
