using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface IVehicleService
    {
        IDataResult<VehicleGetDtoWithObject> GetById(int id);
        IDataResult<IList<VehicleGetDtoWithObject>> GetList();
        IDataResult<VehicleGetDto> Add(VehicleAddDto entity);
        IResult Delete(int id);
        IResult Update(VehicleUpdateDto entity);
    }
}
