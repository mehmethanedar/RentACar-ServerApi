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
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeDal _employeeDal;
        private readonly IMapper _mapper;

        public EmployeeManager(IEmployeeDal employeeDal, IMapper mapper)
        {
            _employeeDal = employeeDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(AddressValidatior))]
        public IDataResult<EmployeeGetDto> Add(Employee entity)
        {
            try
            {
                _employeeDal.Add(entity);
                var getAdd = _employeeDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<EmployeeGetDto>(getAdd);
                return new SuccessDataResult<EmployeeGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<EmployeeGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _employeeDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _employeeDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<EmployeeGetDto> GetById(int id)
        {
            try
            {
                var entity = _employeeDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<EmployeeGetDto>(Messages.NotFound);
                }

                var getList = _mapper.Map<EmployeeGetDto>(entity);
                return new SuccessDataResult<EmployeeGetDto>(getList);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<EmployeeGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<EmployeeGetDto>> GetList()
        {
            try
            {
                var getList = _employeeDal.GetList();
                var get = _mapper.Map<List<EmployeeGetDto>>(getList);
                return new SuccessDataResult<List<EmployeeGetDto>>(get);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<EmployeeGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(AddressValidatior))]
        public IResult Update(EmployeeUpdateDto entity)
        {
            try
            {
                var update = _employeeDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedAddress = _mapper.Map<EmployeeUpdateDto, Employee>(entity, update);
                _employeeDal.Update(update);
                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
