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
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;
        private readonly IMapper _mapper;

        public CityManager(ICityDal cityDal, IMapper mapper)
        {
            _cityDal = cityDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CityValidatior))]
        public IDataResult<CityGetDto> Add(CityAddDto entity)
        {
            try
            {
                var addedCity = _mapper.Map<City>(entity);
                _cityDal.Add(addedCity);

                var getAdd = _cityDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<CityGetDto>(getAdd);
                return new SuccessDataResult<CityGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CityGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _cityDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _cityDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<CityGetDto> GetById(int id)
        {
            try
            {
                var address = _cityDal.Get(p => p.ID == id);
                if (address == null)
                {
                    return new ErrorDataResult<CityGetDto>(Messages.NotFound);
                }

                var addressGet = _mapper.Map<CityGetDto>(address);
                return new SuccessDataResult<CityGetDto>(addressGet);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CityGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<CityGetDto>> GetList()
        {
            try
            {
                var addressList = _cityDal.GetList();
                var addressGetList = _mapper.Map<List<CityGetDto>>(addressList);
                return new SuccessDataResult<List<CityGetDto>>(addressGetList);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<CityGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(CityValidatior))]
        public IResult Update(CityUpdateDto entity)
        {
            try
            {
                var update = _cityDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedAddress = _mapper.Map<CityUpdateDto, City>(entity, update);
                _cityDal.Update(updatedAddress);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
