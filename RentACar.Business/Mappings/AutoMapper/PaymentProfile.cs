﻿using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentAddDto, Payment>();
            CreateMap<Payment, PaymentGetDto>();
            CreateMap<PaymentUpdateDto, Payment>();
        }
    }
}
