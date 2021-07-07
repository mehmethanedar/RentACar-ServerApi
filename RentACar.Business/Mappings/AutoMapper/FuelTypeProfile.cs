using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class FuelTypeProfile : Profile
    {
        public FuelTypeProfile()
        {
            CreateMap<FuelTypeAddDto, FuelType>();
            CreateMap<FuelType, FuelTypeGetDto>();
            CreateMap<FuelTypeUpdateDto, FuelType>();
        }
    }
}
