using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<ColorAddDto, Color>();
            CreateMap<Color, ColorGetDto>();
            CreateMap<ColorUpdateDto, Color>();
        }
    }
}
