using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System.Collections.Generic;

namespace RentACar.Business.Abstract
{
    public interface IPaymentService
    {
        IDataResult<PaymentGetDto> GetById(int id);
        IDataResult<IList<PaymentGetDto>> GetList();
        IDataResult<PaymentGetDto> Add(PaymentAddDto entity);
        IResult Delete(int id);
        IResult Update(PaymentUpdateDto entity);
    }
}
