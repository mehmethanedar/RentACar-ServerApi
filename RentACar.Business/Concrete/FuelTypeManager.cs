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
    public class FuelTypeManager : IFuelTypeService
    {
        private IFuelTypeDal _fuelTypeDal;
        private readonly IMapper _mapper;

        public FuelTypeManager(IFuelTypeDal fuelTypeDal, IMapper mapper)
        {
            _fuelTypeDal = fuelTypeDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(FuelTypeValidatior))]
        public IDataResult<FuelTypeGetDto> Add(FuelTypeAddDto entity)
        {
            try
            {
                var addedFuelType = _mapper.Map<FuelType>(entity);
                _fuelTypeDal.Add(addedFuelType);
                var getAdd = _fuelTypeDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<FuelTypeGetDto>(getAdd);
                return new SuccessDataResult<FuelTypeGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<FuelTypeGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _fuelTypeDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _fuelTypeDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<FuelTypeGetDto> GetById(int id)
        {
            try
            {
                var entity = _fuelTypeDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<FuelTypeGetDto>(Messages.NotFound);
                }

                var getFuelType = _mapper.Map<FuelTypeGetDto>(entity);
                return new SuccessDataResult<FuelTypeGetDto>(getFuelType);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<FuelTypeGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<FuelTypeGetDto>> GetList()
        {
            try
            {
                var getList = _fuelTypeDal.GetList();
                var getListFuelType = _mapper.Map<List<FuelTypeGetDto>>(getList);
                return new SuccessDataResult<List<FuelTypeGetDto>>(getListFuelType);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<FuelTypeGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(FuelTypeValidatior))]
        public IResult Update(FuelTypeUpdateDto entity)
        {
            try
            {
                var update = _fuelTypeDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedFuelType = _mapper.Map<FuelTypeUpdateDto, FuelType>(entity, update);
                _fuelTypeDal.Update(updatedFuelType);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
