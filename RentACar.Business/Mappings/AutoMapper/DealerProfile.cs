using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class DealerProfile : Profile
    {
        public DealerProfile()
        {
            CreateMap<DealerAddDto, Dealer>();
            CreateMap<Dealer, DealerGetDto>();
            CreateMap<DealerUpdateDto, Dealer>();
        }
    }
}
