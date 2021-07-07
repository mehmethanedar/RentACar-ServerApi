using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface IVehicleCategoryService
    {
        IDataResult<VehicleCategoryGetDto> GetById(int id);
        IDataResult<IList<VehicleCategoryGetDto>> GetList();
        IDataResult<VehicleCategoryGetDto> Add(VehicleCategoryAddDto entity);
        IResult Delete(int id);
        IResult Update(VehicleCategoryUpdateDto entity);
    }
}
