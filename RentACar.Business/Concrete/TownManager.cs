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
    public class TownManager : ITownService
    {
        private ITownDal _townDal;
        private readonly IMapper _mapper;

        public TownManager(ITownDal townDal, IMapper mapper)
        {
            _townDal = townDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(TownValidatior))]
        public IDataResult<TownGetDto> Add(TownAddDto entity)
        {
            try
            {
                var addedTown = _mapper.Map<Town>(entity);
                _townDal.Add(addedTown);
                var getAdd = _townDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<TownGetDto>(getAdd);
                return new SuccessDataResult<TownGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<TownGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _townDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _townDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<TownGetDto> GetById(int id)
        {
            try
            {
                var entity = _townDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<TownGetDto>(Messages.NotFound);
                }

                var getTown = _mapper.Map<TownGetDto>(entity);
                return new SuccessDataResult<TownGetDto>(getTown);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<TownGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<TownGetDto>> GetList()
        {
            try
            {
                var getList = _townDal.GetList();
                var getListTown = _mapper.Map<List<TownGetDto>>(getList);
                return new SuccessDataResult<List<TownGetDto>>(getListTown);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<TownGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(TownValidatior))]
        public IResult Update(TownUpdateDto entity)
        {
            try
            {
                var update = _townDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedTown = _mapper.Map<TownUpdateDto, Town>(entity, update);
                _townDal.Update(updatedTown);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
