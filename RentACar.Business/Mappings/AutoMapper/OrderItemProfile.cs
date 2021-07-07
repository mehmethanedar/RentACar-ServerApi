using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItemAddDto, OrderItem>();
            CreateMap<OrderItem, OrderItemGetDto>();
            CreateMap<OrderItemUpdateDto, OrderItem>();
        }
    }
}
