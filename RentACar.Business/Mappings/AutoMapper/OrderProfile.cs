using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderAddDto, Order>();
            CreateMap<Order, OrderGetDto>();
            CreateMap<OrderUpdateDto, Order>();
        }
    }
}
