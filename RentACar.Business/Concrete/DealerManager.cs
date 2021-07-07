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
    public class DealerManager : IDealerService
    {
        private IDealerDal _dealerDal;
        private readonly IMapper _mapper;

        public DealerManager(IDealerDal dealerDal, IMapper mapper)
        {
            _dealerDal = dealerDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(DealerValidatior))]
        public IDataResult<DealerGetDto> Add(DealerAddDto entity)
        {
            try
            {
                var addedDealer = _mapper.Map<Dealer>(entity);
                _dealerDal.Add(addedDealer);

                var getAdd = _dealerDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<DealerGetDto>(getAdd);
                return new SuccessDataResult<DealerGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<DealerGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _dealerDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _dealerDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<DealerGetDto> GetById(int id)
        {
            try
            {
                var entity = _dealerDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<DealerGetDto>(Messages.NotFound);
                }

                var getDealer = _mapper.Map<DealerGetDto>(entity);
                return new SuccessDataResult<DealerGetDto>(getDealer);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<DealerGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<DealerGetDto>> GetList()
        {
            try
            {
                var getList = _dealerDal.GetList();
                var getListDealer = _mapper.Map<List<DealerGetDto>>(getList);
                return new SuccessDataResult<List<DealerGetDto>>(getListDealer);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<DealerGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(DealerValidatior))]
        public IResult Update(DealerUpdateDto entity)
        {
            try
            {
                var update = _dealerDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedDealer = _mapper.Map<DealerUpdateDto, Dealer>(entity, update);
                _dealerDal.Update(updatedDealer);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
