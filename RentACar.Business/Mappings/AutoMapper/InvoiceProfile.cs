using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<InvoiceAddDto, Invoice>();
            CreateMap<Invoice, InvoiceGetDto>();
            CreateMap<InvoiceUpdateDto, Invoice>();
        }
    }
}
