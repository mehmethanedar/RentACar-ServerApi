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
    public interface IOrderService
    {
        IDataResult<OrderGetDto> GetById(int id);
        IDataResult<IList<OrderGetDto>> GetList();
        IDataResult<OrderGetDto> Add(OrderAddDto entity);
        IResult Delete(int id);
        IResult Update(OrderUpdateDto entity);
    }
}
