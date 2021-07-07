using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Business.Abstract
{
    public interface ICaseTypeService
    {
        IDataResult<CaseTypeGetDto> GetById(int id);
        IDataResult<IList<CaseTypeGetDto>> GetList();
        IDataResult<CaseTypeGetDto> Add(CaseTypeAddDto entity);
        IResult Delete(int id);
        IResult Update(CaseTypeUpdateDto entity);
    }
}
