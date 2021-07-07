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
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;
        private readonly IMapper _mapper;

        public PaymentManager(IPaymentDal paymentDal, IMapper mapper)
        {
            _paymentDal = paymentDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(PaymentValidatior))]
        public IDataResult<PaymentGetDto> Add(PaymentAddDto entity)
        {
            try
            {
                var addedPayment = _mapper.Map<Payment>(entity);
                _paymentDal.Add(addedPayment);
                var getAdd = _paymentDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<PaymentGetDto>(getAdd);
                return new SuccessDataResult<PaymentGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<PaymentGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _paymentDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _paymentDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<PaymentGetDto> GetById(int id)
        {
            try
            {
                var entity = _paymentDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<PaymentGetDto>(Messages.NotFound);
                }

                var getPayment = _mapper.Map<PaymentGetDto>(entity);
                return new SuccessDataResult<PaymentGetDto>(getPayment);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<PaymentGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<PaymentGetDto>> GetList()
        {
            try
            {
                var getList = _paymentDal.GetList();
                var getListPayment = _mapper.Map<List<PaymentGetDto>>(getList);
                return new SuccessDataResult<List<PaymentGetDto>>(getListPayment);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<PaymentGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(PaymentValidatior))]
        public IResult Update(PaymentUpdateDto entity)
        {
            try
            {
                var update = _paymentDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedPayment = _mapper.Map<PaymentUpdateDto, Payment>(entity, update);
                _paymentDal.Update(updatedPayment);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
