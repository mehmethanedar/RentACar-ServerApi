using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IUserInformationService
    {
        List<OperationClaim> GetClaims(UserInformation userInformation);
        UserInformation GetByMail(string email);
        IResult ActivateAccount(string accountActivationCode);
        IDataResult<UserInformation> GetById(int id);
        IDataResult<IList<UserInformation>> GetList();
        IResult Add(UserInformation entity);
        IResult Delete(int id);
    }
}
