using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class TownProfile : Profile
    {
        public TownProfile()
        {
            CreateMap<TownAddDto, Town>();
            CreateMap<Town, TownGetDto>();
            CreateMap<TownUpdateDto, Town>();
        }
    }
}
