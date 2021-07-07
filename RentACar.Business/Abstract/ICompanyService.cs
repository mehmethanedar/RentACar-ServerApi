using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Concrete;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<Company> GetById(int id);
        IDataResult<IList<Company>> GetList();
        IDataResult<Company> Add(Company entity);
        IResult Delete(int id);
        IResult Update(Company entity);
    }
}
