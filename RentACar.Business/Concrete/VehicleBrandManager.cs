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
    public class VehicleBrandManager : IVehicleBrandService
    {
        private IVehicleBrandDal _vehicleBrandDal;
        private IVehicleCategoryService _vehicleCategoryService;
        private readonly IMapper _mapper;

        public VehicleBrandManager(IVehicleBrandDal vehicleBrandDal, IMapper mapper, IVehicleCategoryService vehicleCategoryService)
        {
            _vehicleBrandDal = vehicleBrandDal;
            _mapper = mapper;
            _vehicleCategoryService = vehicleCategoryService;
        }

        [ValidationAspect(typeof(VehicleBrandValidatior))]
        public IDataResult<VehicleBrandGetDto> Add(VehicleBrandAddDto entity)
        {
            try
            {
                var addedVehicleBrand = _mapper.Map<VehicleBrand>(entity);
                _vehicleBrandDal.Add(addedVehicleBrand);
                var getAdd = _vehicleBrandDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<VehicleBrandGetDto>(getAdd);
                return new SuccessDataResult<VehicleBrandGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<VehicleBrandGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _vehicleBrandDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _vehicleBrandDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<VehicleBrandGetDto> GetById(int id)
        {
            try
            {
                var entity = _vehicleBrandDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<VehicleBrandGetDto>(Messages.NotFound);
                }

                var getVehicleBrand = _mapper.Map<VehicleBrandGetDto>(entity);
                getVehicleBrand.VehicleCategory= _vehicleCategoryService.GetById(entity.VehicleCategoryID).Data;

                return new SuccessDataResult<VehicleBrandGetDto>(getVehicleBrand);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<VehicleBrandGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<VehicleBrandGetDto>> GetList()
        {
            try
            {
                var getList = _vehicleBrandDal.GetList();
                VehicleBrandGetDto getBrand;
                List<VehicleBrandGetDto> getBrandList = new List<VehicleBrandGetDto>();
                foreach (var item in getList)
                {
                    getBrand = new VehicleBrandGetDto();
                    getBrand.ID = item.ID;
                    getBrand.Name = item.Name;
                    getBrand.VehicleCategory = _vehicleCategoryService.GetById(item.VehicleCategoryID).Data;
                    getBrandList.Add(getBrand);
                }

                return new SuccessDataResult<List<VehicleBrandGetDto>>(getBrandList);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<VehicleBrandGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(VehicleBrandValidatior))]
        public IResult Update(VehicleBrandUpdateDto entity)
        {
            try
            {
                var update = _vehicleBrandDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedVehicleBrand = _mapper.Map<VehicleBrandUpdateDto, VehicleBrand>(entity, update);
                _vehicleBrandDal.Update(updatedVehicleBrand);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
