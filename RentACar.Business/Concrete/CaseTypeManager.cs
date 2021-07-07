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
using RentACar.DataAccess.Concrete.EntityFramework;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentACar.Business.Concrete
{
    [ExceptionLogAspect(typeof(FileLoggerException))]
    [LogAspect(typeof(FileLogger))]
    public class CaseTypeManager : ICaseTypeService
    {
        private ICaseTypeDal _caseTypeDal;
        private readonly IMapper _mapper;

        public CaseTypeManager(ICaseTypeDal caseTypeDal, IMapper mapper)
        {
            _caseTypeDal = caseTypeDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CaseTypeValidatior))]
        public IDataResult<CaseTypeGetDto> Add(CaseTypeAddDto entity)
        {
            try
            {
                var addedCaseType = _mapper.Map<CaseType>(entity);
                _caseTypeDal.Add(addedCaseType);

                var getAdd = _caseTypeDal.GetList().LastOrDefault();

                var getCaseType = _mapper.Map<CaseTypeGetDto>(getAdd);
                return new SuccessDataResult<CaseTypeGetDto>(getCaseType, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CaseTypeGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _caseTypeDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _caseTypeDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<CaseTypeGetDto> GetById(int id)
        {
            try
            {
                var caseType = _caseTypeDal.Get(p => p.ID == id);
                if (caseType == null)
                {
                    return new ErrorDataResult<CaseTypeGetDto>(Messages.NotFound);
                }

                var addressGet = _mapper.Map<CaseTypeGetDto>(caseType);
                return new SuccessDataResult<CaseTypeGetDto>(addressGet);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CaseTypeGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<CaseTypeGetDto>> GetList()
        {
            try
            {
                var caseTypeList = _caseTypeDal.GetList();
                var acaseTypeGetList = _mapper.Map<List<CaseTypeGetDto>>(caseTypeList);
                return new SuccessDataResult<List<CaseTypeGetDto>>(acaseTypeGetList);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<CaseTypeGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(CaseTypeValidatior))]
        public IResult Update(CaseTypeUpdateDto entity)
        {
            try
            {
                var caseType = _caseTypeDal.Get(a => a.ID == entity.ID);
                if (caseType == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedCaseType = _mapper.Map<CaseTypeUpdateDto, CaseType>(entity, caseType);
                _caseTypeDal.Update(updatedCaseType);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
