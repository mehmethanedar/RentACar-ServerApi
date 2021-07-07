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
    public class DriverLicenceManager : IDriverLicenceService
    {
        private IDriverLicenceDal _driverLicenceDal;
        private readonly IMapper _mapper;

        public DriverLicenceManager(IDriverLicenceDal driverLicenceDal, IMapper mapper)
        {
            _driverLicenceDal = driverLicenceDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(DriverLicenceValidatior))]
        public IDataResult<DriverLicenceGetDto> Add(DriverLicenceAddDto entity)
        {
            try
            {
                var addedDriverLicence = _mapper.Map<DriverLicence>(entity);
                _driverLicenceDal.Add(addedDriverLicence);
                var getAdd = _driverLicenceDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<DriverLicenceGetDto>(getAdd);
                return new SuccessDataResult<DriverLicenceGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<DriverLicenceGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _driverLicenceDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _driverLicenceDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<DriverLicenceGetDto> GetById(int id)
        {
            try
            {
                var entity = _driverLicenceDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<DriverLicenceGetDto>(Messages.NotFound);
                }

                var getDriverLicence = _mapper.Map<DriverLicenceGetDto>(entity);
                return new SuccessDataResult<DriverLicenceGetDto>(getDriverLicence);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<DriverLicenceGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<DriverLicenceGetDto>> GetList()
        {
            try
            {
                var getList = _driverLicenceDal.GetList();
                var getListDriverLicence = _mapper.Map<List<DriverLicenceGetDto>>(getList);
                return new SuccessDataResult<List<DriverLicenceGetDto>>(getListDriverLicence);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<DriverLicenceGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(DriverLicenceValidatior))]
        public IResult Update(DriverLicenceUpdateDto entity)
        {
            try
            {
                var update = _driverLicenceDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedDriverLicence = _mapper.Map<DriverLicenceUpdateDto, DriverLicence>(entity, update);
                _driverLicenceDal.Update(updatedDriverLicence);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
