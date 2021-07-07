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
    public class GearTypeManager : IGearTypeService
    {
        private IGearTypeDal _gearTypeDal;
        private readonly IMapper _mapper;

        public GearTypeManager(IGearTypeDal gearTypeDal, IMapper mapper)
        {
            _gearTypeDal = gearTypeDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(GearTypeValidatior))]
        public IDataResult<GearTypeGetDto> Add(GearTypeAddDto entity)
        {
            try
            {
                var addedGearType = _mapper.Map<GearType>(entity);
                _gearTypeDal.Add(addedGearType);

                var getAdd = _gearTypeDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<GearTypeGetDto>(getAdd);
                return new SuccessDataResult<GearTypeGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<GearTypeGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _gearTypeDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _gearTypeDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<GearTypeGetDto> GetById(int id)
        {
            try
            {
                var entity = _gearTypeDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<GearTypeGetDto>(Messages.NotFound);
                }

                var getGearType = _mapper.Map<GearTypeGetDto>(entity);
                return new SuccessDataResult<GearTypeGetDto>(getGearType);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<GearTypeGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<GearTypeGetDto>> GetList()
        {
            try
            {
                var getList = _gearTypeDal.GetList();
                var getListGearType = _mapper.Map<List<GearTypeGetDto>>(getList);
                return new SuccessDataResult<List<GearTypeGetDto>>(getListGearType);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<GearTypeGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(GearTypeValidatior))]
        public IResult Update(GearTypeUpdateDto entity)
        {
            try
            {
                var update = _gearTypeDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedGearType = _mapper.Map<GearTypeUpdateDto, GearType>(entity, update);
                _gearTypeDal.Update(updatedGearType);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
