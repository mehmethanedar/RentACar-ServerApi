using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryAddDto, Country>();
            CreateMap<Country, CountryGetDto>();
            CreateMap<CountryUpdateDto, Country>();
        }
    }
}
