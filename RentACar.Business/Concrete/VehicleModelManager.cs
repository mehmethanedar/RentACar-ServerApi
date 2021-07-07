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
    public class VehicleModelManager : IVehicleModelService
    {
        private IVehicleModelDal _vehicleModelDal;
        private IVehicleBrandService _vehicleBrandService;
        private readonly IMapper _mapper;

        public VehicleModelManager(IVehicleModelDal vehicleModelDal, IMapper mapper, IVehicleBrandService vehicleBrandService)
        {
            _vehicleModelDal = vehicleModelDal;
            _mapper = mapper;
            _vehicleBrandService = vehicleBrandService;
        }

        [ValidationAspect(typeof(VehicleModelValidatior))]
        public IDataResult<VehicleModelGetDto> Add(VehicleModelAddDto entity)
        {
            try
            {
                var addedVehicleModel = _mapper.Map<VehicleModel>(entity);
                _vehicleModelDal.Add(addedVehicleModel);
                var getAdd = _vehicleModelDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<VehicleModelGetDto>(getAdd);
                return new SuccessDataResult<VehicleModelGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<VehicleModelGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _vehicleModelDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _vehicleModelDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<VehicleModelGetDto> GetById(int id)
        {
            try
            {
                var entity = _vehicleModelDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<VehicleModelGetDto>(Messages.NotFound);
                }

                var getVehicleModel = _mapper.Map<VehicleModelGetDto>(entity);
                getVehicleModel.VehicleBrand = _vehicleBrandService.GetById(entity.VehicleBrandID).Data;
                return new SuccessDataResult<VehicleModelGetDto>(getVehicleModel);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<VehicleModelGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<VehicleModelGetDto>> GetList()
        {
            try
            {
                var getList = _vehicleModelDal.GetList();

                var getListVehicleModel = _mapper.Map<List<VehicleModelGetDto>>(getList);
                VehicleModelGetDto getBrand;
                List<VehicleModelGetDto> getBrandList=new List<VehicleModelGetDto>();
                foreach (var item in getList)
                {
                    getBrand = new VehicleModelGetDto();
                    getBrand.ID = item.ID;
                    getBrand.Name = item.Name;
                    getBrand.VehicleBrand = _vehicleBrandService.GetById(item.VehicleBrandID).Data;
                    getBrandList.Add(getBrand);
                }

                return new SuccessDataResult<List<VehicleModelGetDto>>(getBrandList);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<VehicleModelGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(VehicleModelValidatior))]
        public IResult Update(VehicleModelUpdateDto entity)
        {
            try
            {
                var update = _vehicleModelDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedVehicleModel = _mapper.Map<VehicleModelUpdateDto, VehicleModel>(entity, update);
                _vehicleModelDal.Update(updatedVehicleModel);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
