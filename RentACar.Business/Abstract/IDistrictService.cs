using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface IDistrictService
    {
        IDataResult<DistrictGetDto> GetById(int id);
        IDataResult<IList<DistrictGetDto>> GetList();
        IDataResult<DistrictGetDto> Add(DistrictAddDto entity);
        IResult Delete(int id);
        IResult Update(DistrictUpdateDto entity);
    }
}
