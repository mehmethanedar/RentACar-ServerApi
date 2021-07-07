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
    public class VehicleCategoryManager : IVehicleCategoryService
    {
        private IVehicleCategoryDal _vehicleCategoryDal;
        private readonly IMapper _mapper;

        public VehicleCategoryManager(IVehicleCategoryDal vehicleCategoryDal, IMapper mapper)
        {
            _vehicleCategoryDal = vehicleCategoryDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(VehicleCategoryValidatior))]
        public IDataResult<VehicleCategoryGetDto> Add(VehicleCategoryAddDto entity)
        {
            try
            {
                var addedVehicleCategory = _mapper.Map<VehicleCategory>(entity);
                _vehicleCategoryDal.Add(addedVehicleCategory);
                var getAdd = _vehicleCategoryDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<VehicleCategoryGetDto>(getAdd);
                return new SuccessDataResult<VehicleCategoryGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<VehicleCategoryGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _vehicleCategoryDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _vehicleCategoryDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<VehicleCategoryGetDto> GetById(int id)
        {
            try
            {
                var entity = _vehicleCategoryDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<VehicleCategoryGetDto>(Messages.NotFound);
                }

                var getVehicleCategory = _mapper.Map<VehicleCategoryGetDto>(entity);
                return new SuccessDataResult<VehicleCategoryGetDto>(getVehicleCategory);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<VehicleCategoryGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<VehicleCategoryGetDto>> GetList()
        {
            try
            {
                var getList = _vehicleCategoryDal.GetList();
                var getListVehicleCategory = _mapper.Map<List<VehicleCategoryGetDto>>(getList);
                return new SuccessDataResult<List<VehicleCategoryGetDto>>(getListVehicleCategory);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<VehicleCategoryGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(VehicleCategoryValidatior))]
        public IResult Update(VehicleCategoryUpdateDto entity)
        {
            try
            {
                var update = _vehicleCategoryDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedVehicleCategory = _mapper.Map<VehicleCategoryUpdateDto, VehicleCategory>(entity, update);
                _vehicleCategoryDal.Update(updatedVehicleCategory);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
