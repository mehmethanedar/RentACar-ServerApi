using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class GearTypeProfile : Profile
    {
        public GearTypeProfile()
        {
            CreateMap<GearTypeAddDto, GearType>();
            CreateMap<GearType, GearTypeGetDto>();
            CreateMap<GearTypeUpdateDto, GearType>();
        }
    }
}
