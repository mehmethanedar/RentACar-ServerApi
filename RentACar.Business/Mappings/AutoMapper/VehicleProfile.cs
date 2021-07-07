using AutoMapper;
using Newtonsoft.Json;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleAddDto, Vehicle>().ForMember(opt => opt.Pictures, dto => dto.MapFrom(x => JsonConvert.SerializeObject(x.Pictures)));
            CreateMap<Vehicle, VehicleGetDto>().ForMember(dto => dto.Pictures, opt => opt.MapFrom(x => JsonConvert.DeserializeObject<List<string>>(x.Pictures)));
            CreateMap<VehicleUpdateDto, Vehicle>();
            CreateMap<VehicleGetDto, VehicleGetDtoWithObject>();
        }
    }
}
