using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class CaseTypeProfile : Profile
    {
        public CaseTypeProfile()
        {
            CreateMap<CaseTypeAddDto, CaseType>();
            CreateMap<CaseType, CaseTypeGetDto>();
            CreateMap<CaseTypeUpdateDto, CaseType>();
        }
    }
}
