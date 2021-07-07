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
    public class DistrictManager : IDistrictService
    {
        private IDistrictDal _districtDal;
        private readonly IMapper _mapper;

        public DistrictManager(IDistrictDal districtDal, IMapper mapper)
        {
            _districtDal = districtDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(DistrictValidatior))]
        public IDataResult<DistrictGetDto> Add(DistrictAddDto entity)
        {
            try
            {
                var addedDistrict = _mapper.Map<District>(entity);
                _districtDal.Add(addedDistrict);
                var getAdd = _districtDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<DistrictGetDto>(getAdd);
                return new SuccessDataResult<DistrictGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<DistrictGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _districtDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _districtDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<DistrictGetDto> GetById(int id)
        {
            try
            {
                var entity = _districtDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<DistrictGetDto>(Messages.NotFound);
                }

                var getDistrict = _mapper.Map<DistrictGetDto>(entity);
                return new SuccessDataResult<DistrictGetDto>(getDistrict);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<DistrictGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<DistrictGetDto>> GetList()
        {
            try
            {
                var getList = _districtDal.GetList();
                var getListDistrict = _mapper.Map<List<DistrictGetDto>>(getList);
                return new SuccessDataResult<List<DistrictGetDto>>(getListDistrict);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<DistrictGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(DistrictValidatior))]
        public IResult Update(DistrictUpdateDto entity)
        {
            try
            {
                var update = _districtDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedDistrict = _mapper.Map<DistrictUpdateDto, District>(entity, update);
                _districtDal.Update(updatedDistrict);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
