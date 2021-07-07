using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressAddDto, Address>();
            CreateMap<Address, AddressGetDto>();
            CreateMap<AddressUpdateDto, Address>();
        }
    }
}
