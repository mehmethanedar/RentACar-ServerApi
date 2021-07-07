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
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;
        private readonly IMapper _mapper;

        public ColorManager(IColorDal colorDal, IMapper mapper)
        {
            _colorDal = colorDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(ColorValidatior))]
        public IDataResult<ColorGetDto> Add(ColorAddDto entity)
        {
            try
            {
                var addedColor = _mapper.Map<Color>(entity);
                _colorDal.Add(addedColor);
                var getAdd = _colorDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<ColorGetDto>(getAdd);
                return new SuccessDataResult<ColorGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ColorGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _colorDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _colorDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<ColorGetDto> GetById(int id)
        {
            try
            {
                var entity = _colorDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<ColorGetDto>(Messages.NotFound);
                }

                var getColor = _mapper.Map<ColorGetDto>(entity);
                return new SuccessDataResult<ColorGetDto>(getColor);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ColorGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<ColorGetDto>> GetList()
        {
            try
            {
                var getList = _colorDal.GetList();
                var getListColor = _mapper.Map<List<ColorGetDto>>(getList);
                return new SuccessDataResult<List<ColorGetDto>>(getListColor);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<ColorGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(ColorValidatior))]
        public IResult Update(ColorUpdateDto entity)
        {
            try
            {
                var update = _colorDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedColor = _mapper.Map<ColorUpdateDto, Color>(entity, update);
                _colorDal.Update(updatedColor);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
