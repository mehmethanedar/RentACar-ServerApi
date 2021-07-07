using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface IColorService
    {
        IDataResult<ColorGetDto> GetById(int id);
        IDataResult<IList<ColorGetDto>> GetList();
        IDataResult<ColorGetDto> Add(ColorAddDto entity);
        IResult Delete(int id);
        IResult Update(ColorUpdateDto entity);
    }
}
