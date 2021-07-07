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
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;
        private readonly IMapper _mapper;

        public AddressManager(IAddressDal addressDal, IMapper mapper)
        {
            _addressDal = addressDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(AddressValidatior))]
        public IDataResult<AddressGetDto> Add(AddressAddDto entity)
        {
            try
            {
                var addedAddress = _mapper.Map<Address>(entity);
                _addressDal.Add(addedAddress);
                
                var getAdd = _addressDal.GetList().LastOrDefault();

                var getAddress = _mapper.Map<AddressGetDto>(getAdd);
                return new SuccessDataResult<AddressGetDto>(getAddress, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<AddressGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _addressDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _addressDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<AddressGetDto> GetById(int id)
        {
            try
            {
                var entity = _addressDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<AddressGetDto>(Messages.NotFound);
                }

                var getAddress = _mapper.Map<AddressGetDto>(entity);
                return new SuccessDataResult<AddressGetDto>(getAddress);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<AddressGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<AddressGetDto>> GetList()
        {
            try
            {
                var getList = _addressDal.GetList();
                var getListAddress = _mapper.Map<List<AddressGetDto>>(getList);
                return new SuccessDataResult<List<AddressGetDto>>(getListAddress);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<AddressGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(AddressValidatior))]
        public IResult Update(AddressUpdateDto entity)
        {
            try
            {
                var update = _addressDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedAddress = _mapper.Map<AddressUpdateDto, Address>(entity, update);
                _addressDal.Update(updatedAddress);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
