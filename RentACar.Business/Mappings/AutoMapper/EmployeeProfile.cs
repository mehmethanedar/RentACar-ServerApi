using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;

namespace RentACar.Business.Mappings.AutoMapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeGetDto>();
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}
