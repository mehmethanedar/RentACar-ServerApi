using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface IVehicleModelService
    {
        IDataResult<VehicleModelGetDto> GetById(int id);
        IDataResult<IList<VehicleModelGetDto>> GetList();
        IDataResult<VehicleModelGetDto> Add(VehicleModelAddDto entity);
        IResult Delete(int id);
        IResult Update(VehicleModelUpdateDto entity);
    }
}
