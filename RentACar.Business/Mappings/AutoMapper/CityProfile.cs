using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityAddDto, City>();
            CreateMap<City, CityGetDto>();
            CreateMap<CityUpdateDto, City>();
        }
    }
}
