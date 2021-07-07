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
    public class CountryManager : ICountryService
    {
        private ICountryDal _countryDal;
        private readonly IMapper _mapper;
        public CountryManager(ICountryDal CountryDal, IMapper mapper)
        {
            _countryDal = CountryDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CountryValidatior))]
        public IDataResult<CountryGetDto> Add(CountryAddDto entity)
        {
            try
            {
                var addedCountry = _mapper.Map<Country>(entity);
                _countryDal.Add(addedCountry);
                var getAdd = _countryDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<CountryGetDto>(getAdd);
                return new SuccessDataResult<CountryGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CountryGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _countryDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _countryDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<CountryGetDto> GetById(int id)
        {
            try
            {
                var entity = _countryDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<CountryGetDto>(Messages.NotFound);
                }

                var getCountry = _mapper.Map<CountryGetDto>(entity);
                return new SuccessDataResult<CountryGetDto>(getCountry);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CountryGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<CountryGetDto>> GetList()
        {
            try
            {
                var getList = _countryDal.GetList();
                var getListCountry = _mapper.Map<List<CountryGetDto>>(getList);
                return new SuccessDataResult<List<CountryGetDto>>(getListCountry);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<CountryGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(CountryValidatior))]
        public IResult Update(CountryUpdateDto entity)
        {
            try
            {
                var update = _countryDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedCountry = _mapper.Map<CountryUpdateDto, Country>(entity, update);
                _countryDal.Update(updatedCountry);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
