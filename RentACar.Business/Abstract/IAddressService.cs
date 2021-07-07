using System.Collections.Generic;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Update;
using RentACar.Core.Utilities.Results.Abstract;

namespace RentACar.Business.Abstract
{
    public interface IAddressService
    {
        IDataResult<AddressGetDto> GetById(int id);
        IDataResult<IList<AddressGetDto>> GetList();
        IDataResult<AddressGetDto> Add(AddressAddDto entity);
        IResult Delete(int id);
        IResult Update(AddressUpdateDto entity);
    }
}
