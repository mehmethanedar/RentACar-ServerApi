using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class PaymentTypeProfile : Profile
    {
        public PaymentTypeProfile()
        {
            CreateMap<PaymentTypeAddDto, PaymentType>();
            CreateMap<PaymentType, PaymentTypeGetDto>();
            CreateMap<PaymentTypeUpdateDto, PaymentType>();
        }
    }
}
