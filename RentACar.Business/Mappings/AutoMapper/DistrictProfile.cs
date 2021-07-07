using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class DistrictProfile : Profile
    {
        public DistrictProfile()
        {
            CreateMap<DistrictAddDto, District>();
            CreateMap<District, DistrictGetDto>();
            CreateMap<DistrictUpdateDto, District>();
        }
    }
}
