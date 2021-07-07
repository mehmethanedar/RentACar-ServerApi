using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class DriverLicenceProfile : Profile
    {
        public DriverLicenceProfile()
        {
            CreateMap<DriverLicenceAddDto, DriverLicence>();
            CreateMap<DriverLicence, DriverLicenceGetDto>();
            CreateMap<DriverLicenceUpdateDto, DriverLicence>();
        }
    }
}
