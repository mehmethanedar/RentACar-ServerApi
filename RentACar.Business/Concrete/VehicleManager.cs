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
    public class VehicleManager : IVehicleService
    {
        private IVehicleDal _vehicleDal;
        private readonly IMapper _mapper;
        private readonly ICaseTypeDal _caseTypeDal;
        private readonly IFuelTypeDal _fuelTypeDal;
        private readonly IGearTypeDal _gearTypeDal;
        private readonly IVehicleModelDal _vehicleModelDal;
        private readonly IColorDal _colorDal;
        private readonly IVehicleBrandDal _vehicleBrandDal;
        private readonly IVehicleCategoryDal _vehicleCategoryDal;

        public VehicleManager(
            IVehicleDal VehicleDal,
            IMapper mapper,
            ICaseTypeDal caseTypeDal,
            IFuelTypeDal fuelTypeDal,
            IGearTypeDal gearTypeDal,
            IVehicleModelDal vehicleModelDal,
            IColorDal colorDal,
            IVehicleBrandDal vehicleBrandDal,
            IVehicleCategoryDal vehicleCategoryDal)
        {
            _vehicleDal = VehicleDal;
            _mapper = mapper;
            _caseTypeDal = caseTypeDal;
            _fuelTypeDal = fuelTypeDal;
            _gearTypeDal = gearTypeDal;
            _vehicleModelDal = vehicleModelDal;
            _colorDal = colorDal;
            _vehicleBrandDal = vehicleBrandDal;
            _vehicleCategoryDal = vehicleCategoryDal;
        }

        [ValidationAspect(typeof(VehicleValidatior))]
        public IDataResult<VehicleGetDto> Add(VehicleAddDto entity)
        {
            try
            {
                var addedVehicle = _mapper.Map<Vehicle>(entity);
                _vehicleDal.Add(addedVehicle);
                var getAdd = _vehicleDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<VehicleGetDto>(getAdd);
                return new SuccessDataResult<VehicleGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<VehicleGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _vehicleDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _vehicleDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<VehicleGetDtoWithObject> GetById(int id)
        {
            try
            {
                var entity = _vehicleDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<VehicleGetDtoWithObject>(Messages.NotFound);
                }

                var getVehicle = _mapper.Map<VehicleGetDto>(entity);
                getVehicle.CaseType = _caseTypeDal.Get(x => x.ID == getVehicle.CaseTypeID);
                getVehicle.FuelType = _fuelTypeDal.Get(x => x.ID == getVehicle.FuelTypeID);
                getVehicle.GearType = _gearTypeDal.Get(x => x.ID == getVehicle.GearTypeID);
                getVehicle.Color = _colorDal.Get(x => x.ID == getVehicle.ColorID);
                getVehicle.VehicleModel = _vehicleModelDal.Get(x => x.ID == getVehicle.VehicleModelID);
                getVehicle.VehicleModel.VehicleBrand = _vehicleBrandDal.Get(x => 
                    x.ID == getVehicle.VehicleModel.VehicleBrandID);
                getVehicle.VehicleModel.VehicleBrand.VehicleCategory = _vehicleCategoryDal.Get(x =>
                    x.ID == getVehicle.VehicleModel.VehicleBrand.VehicleCategoryID);

                var gtVehicle = _mapper.Map<VehicleGetDtoWithObject>(getVehicle);
                return new SuccessDataResult<VehicleGetDtoWithObject>(gtVehicle);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<VehicleGetDtoWithObject>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<VehicleGetDtoWithObject>> GetList()
        {
            try
            {
                var getList = _vehicleDal.GetList();
                var getListVehicle = _mapper.Map<List<VehicleGetDto>>(getList);
                for (int i = 0; i < getList.Count; i++)
                {
                    getListVehicle[i].CaseType = _caseTypeDal.Get(x => x.ID == getListVehicle[i].CaseTypeID);
                    getListVehicle[i].FuelType = _fuelTypeDal.Get(x => x.ID == getListVehicle[i].FuelTypeID);
                    getListVehicle[i].GearType = _gearTypeDal.Get(x => x.ID == getListVehicle[i].GearTypeID);
                    getListVehicle[i].Color = _colorDal.Get(x => x.ID == getListVehicle[i].ColorID);
                    getListVehicle[i].VehicleModel = _vehicleModelDal.Get(x => x.ID == getListVehicle[i].VehicleModelID);
                    getListVehicle[i].VehicleModel.VehicleBrand = _vehicleBrandDal.Get(x =>
                        x.ID == getListVehicle[i].VehicleModel.VehicleBrandID);
                    getListVehicle[i].VehicleModel.VehicleBrand.VehicleCategory = _vehicleCategoryDal.Get(x =>
                        x.ID == getListVehicle[i].VehicleModel.VehicleBrand.VehicleCategoryID);
                }
                var gtListVehicle = _mapper.Map<List<VehicleGetDtoWithObject>>(getListVehicle);
                return new SuccessDataResult<List<VehicleGetDtoWithObject>>(gtListVehicle);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<VehicleGetDtoWithObject>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(VehicleValidatior))]
        public IResult Update(VehicleUpdateDto entity)
        {
            try
            {
                var update = _vehicleDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedVehicle = _mapper.Map<VehicleUpdateDto, Vehicle>(entity, update);
                _vehicleDal.Update(updatedVehicle);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
