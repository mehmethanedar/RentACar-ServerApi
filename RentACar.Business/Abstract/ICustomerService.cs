using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetById(int id);
        IDataResult<IList<Customer>> GetList();
        IDataResult<CustomerGetDto> Add(CustomerAddDto entity);
        IResult Delete(int id);
        IResult Update(Customer entity);
    }
}
