using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface IDriverLicenceService
    {
        IDataResult<DriverLicenceGetDto> GetById(int id);
        IDataResult<IList<DriverLicenceGetDto>> GetList();
        IDataResult<DriverLicenceGetDto> Add(DriverLicenceAddDto entity);
        IResult Delete(int id);
        IResult Update(DriverLicenceUpdateDto entity);
    }
}
