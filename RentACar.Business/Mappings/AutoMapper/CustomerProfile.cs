using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerAddDto, Customer>();
            CreateMap<Customer, CustomerGetDto>();
            //CreateMap<CustomerUpdateDto, Customer>();
        }
    }
}
