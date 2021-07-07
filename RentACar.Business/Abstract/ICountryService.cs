using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface ICountryService
    {
        IDataResult<CountryGetDto> GetById(int id);
        IDataResult<IList<CountryGetDto>> GetList();
        IDataResult<CountryGetDto> Add(CountryAddDto entity);
        IResult Delete(int id);
        IResult Update(CountryUpdateDto entity);
    }
}
