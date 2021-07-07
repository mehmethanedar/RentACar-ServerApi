using AutoMapper;
using RentACar.Business.Abstract;
using RentACar.Business.Contants;
using RentACar.Business.ValidationRules.FluentValidation;
using RentACar.Core.Aspects.Autofac;
using RentACar.Core.Aspects.Autofac.Exception;
using RentACar.Core.Aspects.Autofac.Logging;
using RentACar.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Business.Concrete
{
    [ExceptionLogAspect(typeof(FileLoggerException))]
    [LogAspect(typeof(FileLogger))]
    public class OrderItemManager : IOrderItemService
    {
        private IOrderItemDal _orderItemDal;
        private readonly IMapper _mapper;

        public OrderItemManager(IOrderItemDal orderItemDal, IMapper mapper)
        {
            _orderItemDal = orderItemDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(OrderItemValidatior))]
        public IDataResult<OrderItemGetDto> Add(OrderItemAddDto entity)
        {
            try
            {
                var addedOrderItem = _mapper.Map<OrderItem>(entity);
                _orderItemDal.Add(addedOrderItem);
                var getAdd = _orderItemDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<OrderItemGetDto>(getAdd);
                return new SuccessDataResult<OrderItemGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<OrderItemGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _orderItemDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _orderItemDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<OrderItemGetDto> GetById(int id)
        {
            try
            {
                var entity = _orderItemDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<OrderItemGetDto>(Messages.NotFound);
                }

                var getOrderItem = _mapper.Map<OrderItemGetDto>(entity);
                return new SuccessDataResult<OrderItemGetDto>(getOrderItem);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<OrderItemGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<OrderItemGetDto>> GetList()
        {
            try
            {
                var getList = _orderItemDal.GetList();
                var getListOrderItem = _mapper.Map<List<OrderItemGetDto>>(getList);
                return new SuccessDataResult<List<OrderItemGetDto>>(getListOrderItem);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<OrderItemGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(OrderItemValidatior))]
        public IResult Update(OrderItemUpdateDto entity)
        {
            try
            {
                var update = _orderItemDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedOrderItem = _mapper.Map<OrderItemUpdateDto, OrderItem>(entity, update);
                _orderItemDal.Update(updatedOrderItem);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
