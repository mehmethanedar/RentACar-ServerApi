using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface IVehicleBrandService
    {
        IDataResult<VehicleBrandGetDto> GetById(int id);
        IDataResult<IList<VehicleBrandGetDto>> GetList();
        IDataResult<VehicleBrandGetDto> Add(VehicleBrandAddDto entity);
        IResult Delete(int id);
        IResult Update(VehicleBrandUpdateDto entity);
    }
}
