using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface ICityService
    {
        IDataResult<CityGetDto> GetById(int id);
        IDataResult<IList<CityGetDto>> GetList();
        IDataResult<CityGetDto> Add(CityAddDto entity);
        IResult Delete(int id);
        IResult Update(CityUpdateDto entity);
    }
}
