using AutoMapper;
using RentACar.Business.Abstract;
using RentACar.Business.Contants;
using RentACar.Business.ValidationRules.FluentValidation;
using RentACar.Core.Aspects.Autofac;
using RentACar.Core.Aspects.Autofac.Exception;
using RentACar.Core.Aspects.Autofac.Logging;
using RentACar.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using RentACar.Core.Utilities.Results;
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
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    [ExceptionLogAspect(typeof(FileLoggerException))]
    [LogAspect(typeof(FileLogger))]
    public class PaymentTypeManager : IPaymentTypeService
    {
        private IPaymentTypeDal _paymentTypeDal;
        private readonly IMapper _mapper;

        public PaymentTypeManager(IPaymentTypeDal paymentTypeDal, IMapper mapper)
        {
            _paymentTypeDal = paymentTypeDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(PaymentTypeValidatior))]
        public IDataResult<PaymentTypeGetDto> Add(PaymentTypeAddDto entity)
        {
            try
            {
                var addedPaymentType = _mapper.Map<PaymentType>(entity);
                _paymentTypeDal.Add(addedPaymentType);
                var getAdd = _paymentTypeDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<PaymentTypeGetDto>(getAdd);
                return new SuccessDataResult<PaymentTypeGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<PaymentTypeGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _paymentTypeDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _paymentTypeDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<PaymentTypeGetDto> GetById(int id)
        {
            try
            {
                var entity = _paymentTypeDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<PaymentTypeGetDto>(Messages.NotFound);
                }

                var getPaymentType = _mapper.Map<PaymentTypeGetDto>(entity);
                return new SuccessDataResult<PaymentTypeGetDto>(getPaymentType);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<PaymentTypeGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<PaymentTypeGetDto>> GetList()
        {
            try
            {
                var getList = _paymentTypeDal.GetList();
                var getListPaymentType = _mapper.Map<List<PaymentTypeGetDto>>(getList);
                return new SuccessDataResult<List<PaymentTypeGetDto>>(getListPaymentType);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<PaymentTypeGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(PaymentTypeValidatior))]
        public IResult Update(PaymentTypeUpdateDto entity)
        {
            try
            {
                var update = _paymentTypeDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedPaymentType = _mapper.Map<PaymentTypeUpdateDto, PaymentType>(entity, update);
                _paymentTypeDal.Update(updatedPaymentType);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
