using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<EmployeeGetDto> GetById(int id);
        IDataResult<IList<EmployeeGetDto>> GetList();
        IDataResult<EmployeeGetDto> Add(Employee entity);
        IResult Delete(int id);
        IResult Update(EmployeeUpdateDto entity);
    }
}
