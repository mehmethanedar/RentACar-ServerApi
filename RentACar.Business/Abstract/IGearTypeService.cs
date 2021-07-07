﻿using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface IGearTypeService
    {
        IDataResult<GearTypeGetDto> GetById(int id);
        IDataResult<IList<GearTypeGetDto>> GetList();
        IDataResult<GearTypeGetDto> Add(GearTypeAddDto entity);
        IResult Delete(int id);
        IResult Update(GearTypeUpdateDto entity);
    }
}
