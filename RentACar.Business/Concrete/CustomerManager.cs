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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    [ExceptionLogAspect(typeof(FileLoggerException))]
    [LogAspect(typeof(FileLogger))]
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        private readonly IMapper _mapper;

        public CustomerManager(ICustomerDal CustomerDal, IMapper mapper)
        {
            _customerDal = CustomerDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(AddressValidatior))]
        public IDataResult<CustomerGetDto> Add(CustomerAddDto entity)
        {
            try
            {
                var addedCustomer = _mapper.Map<Customer>(entity);
                _customerDal.Add(addedCustomer); 
                var getAdd = _customerDal.GetList().LastOrDefault();

                var getCustomer = _mapper.Map<CustomerGetDto>(getAdd);
                return new SuccessDataResult<CustomerGetDto>(getCustomer, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CustomerGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _customerDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _customerDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<Customer> GetById(int id)
        {
            try
            {
                var entity = _customerDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<Customer>(Messages.NotFound);
                }

                return new SuccessDataResult<Customer>(entity);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Customer>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<Customer>> GetList()
        {
            try
            {
                var getList = _customerDal.GetList();
                return new SuccessDataResult<List<Customer>>(getList.ToList());
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Customer>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(AddressValidatior))]
        public IResult Update(Customer entity)
        {
            try
            {
                var update = _customerDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _customerDal.Update(update);
                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
