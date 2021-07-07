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
    public interface IOrderItemService
    {
        IDataResult<OrderItemGetDto> GetById(int id);
        IDataResult<IList<OrderItemGetDto>> GetList();
        IDataResult<OrderItemGetDto> Add(OrderItemAddDto entity);
        IResult Delete(int id);
        IResult Update(OrderItemUpdateDto entity);
    }
}
