using RentACar.Business.Abstract;
using RentACar.Business.Contants;
using RentACar.Core.Aspects.Autofac;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
using RentACar.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class UserInformationManager : IUserInformationService
    {
        private IUserInformationDal _userInformationDal;

        public UserInformationManager(IUserInformationDal UserInformationDal)
        {
            _userInformationDal = UserInformationDal;
        }

        public IResult ActivateAccount(string accountActivationCode)
        {
            try
            {
                var entity = _userInformationDal.Get(c => c.ActivationCode == accountActivationCode);
                if (entity == null)
                {
                    return new ErrorResult(Messages.AccountActivationCodeInvalid);
                }

                entity.Status = true;
                _userInformationDal.Update(entity);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.AnErrorOccurred);
            }
            
        }

        public UserInformation GetByMail(string email)
        {
            return _userInformationDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(UserInformation userInformation)
        {
            return _userInformationDal.GetClaims(userInformation);
        }

        public IDataResult<IList<UserInformation>> GetList()
        {
            try
            {
                var getList = _userInformationDal.GetList();
                return new SuccessDataResult<List<UserInformation>>(getList.ToList());
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<UserInformation>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Add(UserInformation entity)
        {
            try
            {
                _userInformationDal.Add(entity);
                return new SuccessResult(Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnAddition + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _userInformationDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _userInformationDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<UserInformation> GetById(int id)
        {
            try
            {
                var entity = _userInformationDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<UserInformation>(Messages.NotFound);
                }

                return new SuccessDataResult<UserInformation>(entity);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<UserInformation>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }
    }
}
