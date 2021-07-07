using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface IDealerService
    {
        IDataResult<DealerGetDto> GetById(int id);
        IDataResult<IList<DealerGetDto>> GetList();
        IDataResult<DealerGetDto> Add(DealerAddDto entity);
        IResult Delete(int id);
        IResult Update(DealerUpdateDto entity);
    }
}
