using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ITownService
    {
        IDataResult<TownGetDto> GetById(int id);
        IDataResult<IList<TownGetDto>> GetList();
        IDataResult<TownGetDto> Add(TownAddDto entity);
        IResult Delete(int id);
        IResult Update(TownUpdateDto entity);
    }
}
