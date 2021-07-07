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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    [ExceptionLogAspect(typeof(FileLoggerException))]
    [LogAspect(typeof(FileLogger))]
    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        [ValidationAspect(typeof(AddressValidatior))]
        public IDataResult<Company> Add(Company entity)
        {
            try
            {
                _companyDal.Add(entity);
                var getAdd = _companyDal.GetList().LastOrDefault();

                return new SuccessDataResult<Company>(getAdd, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Company>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _companyDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _companyDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<Company> GetById(int id)
        {
            try
            {
                var entity = _companyDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<Company>(Messages.NotFound);
                }

                return new SuccessDataResult<Company>(entity);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Company>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<Company>> GetList()
        {
            try
            {
                var getList = _companyDal.GetList();
                return new SuccessDataResult<List<Company>>(getList.ToList());
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Company>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(AddressValidatior))]
        public IResult Update(Company entity)
        {
            try
            {
                var update = _companyDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _companyDal.Update(update);
                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
